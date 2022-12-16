using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PdfSacannerAlfaVersion.Model.ReportGoogle
{
    class GoogleHelper
    {
        private readonly string token;
        private readonly string filename;
        private UserCredential credentials;
        private DriveService driveService;
        private SheetsService sheetsService;
        private string SheetFileId;
        private string sheetfilename;

        public GoogleHelper(string token, string filename)
        {
            this.token = token;
            this.filename = filename;

        }

        public string ApplicanName { get; private set; } = "ExcelLenta";
        public string[] Scopes { get; private set; } = new string[] { DriveService.Scope.Drive, SheetsService.Scope.Spreadsheets };

        internal void Set(string cellName1, string value)
        {
            var range = this.sheetfilename + "!" + cellName1;
            var values = new List<List<Object>> { new List<object> { value } };

            var req = this.sheetsService.Spreadsheets.Values.Update(
                new Google.Apis.Sheets.v4.Data.ValueRange { Values = new List<IList<Object>>(values) },
                spreadsheetId: this.SheetFileId,
                range: range);
            req.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = req.Execute();
        }

        internal void SetD(string cellName1, string cellName2, string value, string value2)
        {
            var range = this.sheetfilename + "!" + cellName1 + ":" + cellName2;
            var values = new List<List<Object>> { new List<object> { value, value2 } };

            var req = this.sheetsService.Spreadsheets.Values.Update(
                new Google.Apis.Sheets.v4.Data.ValueRange { Values = new List<IList<Object>>(values) },
                spreadsheetId: this.SheetFileId,
                range: range);
            req.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = req.Execute();
        }

        internal Google.Apis.Sheets.v4.Data.ValueRange Get()
        {
            var range = this.sheetfilename + "!" + "C:C";
            var req = this.sheetsService.Spreadsheets.Values.Get(
                spreadsheetId: this.SheetFileId,
                range: range);
            var response = req.Execute();

            return response;

        }

        internal async Task<bool> Start()
        {
            using (var stm = new MemoryStream(Encoding.UTF8.GetBytes(this.token)))
            {
                string credentialPath = Path.Combine(Environment.CurrentDirectory, ".credentials", ApplicanName);
                this.credentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets: GoogleClientSecrets.FromStream(stm).Secrets,
                    scopes: this.Scopes,
                    user: "user",
                    taskCancellationToken: CancellationToken.None,
                    new FileDataStore(credentialPath, true));
            }

            this.driveService = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = this.credentials,
                ApplicationName = ApplicanName,

            });

            this.sheetsService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = this.credentials,
                ApplicationName = ApplicanName,

            });

            var req = this.driveService.Files.List();
            var res = req.Execute();

            foreach (var file in res.Files)
            {
                if (file.Name == this.filename)
                {
                    this.SheetFileId = file.Id;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(this.SheetFileId))
            {
                var sheetReq = this.sheetsService.Spreadsheets.Get(this.SheetFileId);
                var sheetRes = sheetReq.Execute();

                this.sheetfilename = sheetRes.Sheets[0].Properties.Title;

                return true;
            }


            return false;

        }
    }
}
