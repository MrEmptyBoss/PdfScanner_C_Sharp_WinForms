# Select the language
***
[ENG](#eng)
[RUS](#rus)
***
<a id="eng"></a>
# ENG Version
___A program for calculating the fill of pdf layout files___

The program was developed for the printing house to improve the speed for calculating the filling of pdf files.
It was made in C# Windows Forms on the pattern:
MVVM is a development pattern that allows you to divide the application into three functional parts:
Model — the main logic of the program (working with data, calculations, queries, and so on)
View — view or view (user interface)
ViewModel is a view model that serves as a layer between View and Model
Advantage of the program:
- The ability to select several files for calculating the fill and checks with the table that was copied in advance;
- Checks the dimensions with the table;
- Finds broken and damaged pdf pages.
- In the "report" tab, automates the process of filling in rows in Excel.

# Video demonstration of the program
___Click on the picture to view___
[![WATCH ME](https://upwork-usw2-prod-agora-file-storage.s3.us-west-2.amazonaws.com/profile/portfolio/thumbnail/2b2ada1b60d323a02feecd531482d901?response-content-disposition=inline;+filename=%22image_original%22;+filename*=utf-8%27%27image_original&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEOH//////////wEaCXVzLXdlc3QtMiJIMEYCIQCvfEzWoUmlPgFALhu5E8uu0A0WxoGF4LxPXBIJXsYdegIhANK/%2BoBKKgpT/mB91Gz7hCoeEUyQkSDERM/R2bcCUcz0Ks0ECBoQABoMNzM5OTM5MTczODE5Igwfp4tSu6ddtVpy02gqqgR/IPdov8P37uyO2%2BLPbtJ1qecdeQmGkMcm4xK7sxVzzYk%2BXQPbpHxgt/1duB1Iix679POy5chUeG5vfgFzd91N1mY%2Bt6OFEojdYu7JS/TawF7WpqTb0tF3FswRXidlsFgxSq5Knk7NsBtmrnBZmzvKQdYxoMb9jEMCxx1cS5G80gqK7awslgtW/ANxzLdvaOZv5jhIWWKPLY33X2xu/8oBmGjPx2529t1C5SnRPYIjS%2B9GljodoPIHHkzduMw%2BcgAiXlAIhLqNvKIpl6nrrUqBgpJl4V9CdQ5v6DpWn%2B%2BQLT4uUdIk2p%2BGwq30Wszu3hJuxtmYpXqKSS5rAF6Cg8SzO9JyZ9QaZWN/zEc4oz9K5ZXO4aFUYwbW2iIrFricESCQHyJRh7sEbKJnpdLfVgzoStKM5YAOaCxHCtWzOblXME47D%2Bh8jIUJANxMo8qhd8%2B3RtjpCNjHEeyodPJuVqxkuRZbBB7pTTYwKkBOeOWAfOJAc6P65oowZxjxino6dcuZI8qDRsrMRMHj2cEVC33v1x/U2MGfXWgj8vMZ/bbKYUSqrkm/yJdyaEZJwpZCuOM3wyj%2BsrexcCfZJ3kDXGSL2k6Ss55CeFjuxq9uiEVleRri8MyzTz3nKlyGjBeUIKkAwMZ3GPnzJM0ZJ8dT2VjPTe0pkOPnMZBlXmxpYkmgp6l6HVUpgJ0iC8mPE7Kk6hvRa2DbupzLkUl1y8cVbmepo2lXnqnohMrIOTDIxvKcBjqmAWYhEotraG625HGk03AU%2BUumOIKwuRqM2lFLH3bKFMJ6/dOoPpNxGrQbPQqGkjcurCng15w7CVhts6iika80eFkr0u2KfwbJ4q2BNIrFyDFrck7446W16065%2B7E/ef%2B9BE%2BvNH%2BoGGkZVyEkrqNa7NOB0sW1u5uBd04mtKSfCGQxptrM/qXxl1Goq%2Bfas6%2Bh4PHj2ThMpPbCsDcuP9%2BNv/MoyJg69QI=&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20221216T183429Z&X-Amz-SignedHeaders=host&X-Amz-Expires=900&X-Amz-Credential=ASIA2YR6PYW572LKKVMA/20221216/us-west-2/s3/aws4_request&X-Amz-Signature=29ced7d62dc4a8a1803f201683d32bbfec972d7476f4d290a377aba7bfcf3c90)](https://youtu.be/3JEToPbr6yw)
# Screenshots
___File Scanning interface___
![Alt text](https://upwork-usw2-prod-agora-file-storage.s3.us-west-2.amazonaws.com/profile/portfolio/thumbnail/2b2ada1b60d323a02feecd531482d901?response-content-disposition=inline;+filename=%22image_original%22;+filename*=utf-8%27%27image_original&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEOL//////////wEaCXVzLXdlc3QtMiJHMEUCIAzuLDc46wjhMrD/153uK9qJ9luvz5QeyBmS/rAvJcwgAiEAkqJ6w/G9qv5KRA2RwL/8CL6co1mnZ9ygMODShF%2BM2jsqzQQIGhAAGgw3Mzk5MzkxNzM4MTkiDDvRlDhKnkLAyago8CqqBG37K6ycm6cy3sJ8W/voQDBDx0irSr6YszABDK5ZZHI5TQCmowOCEiEsdH9Av4RukKwBGXh4gcMcAlwnLOAJuA0i9/tRfLdBB2AL5nm41r1uoWteHAuCu70sjsPZb3j2xwMURzzUtE6ZNzlMiEv0UMAz%2Bsb8Oh5RNPn0Jltm5fvYlLrRjRhXiRtnKdR/APppuwA14w0whgPc5mQxpOtvuSf6nw%2BqB/vzKDSaWYWAQ2XMqLxkwRUwk4025KK%2Bh4p/8QD9Vzt0lw%2BDf9/ozgxOrBUmjI6SiwRSqTnPgZFAs90jYFHK2zQ9Kinul9N80HIJOUNsmYjXP0L82llQ3R8hz8Cy%2BQBbDyCHkXFlhdIpe/7nELzDqrqx6l%2BHOPQ5WlR1WJwq%2BauomSqH9c%2B31eFCGolaZ8C5I1D/0OrTjjl7/oTV9LAYqlFm22%2BSgzMtrx%2BdAMr5s5%2BYHpCoqivOwX7JQ4/XGvPtj7K%2Bll2JIOBJItLOM4l92GSMBwjJDEQyqzvG7lX/fqV88NRTD6g0pQfb5gbIfvELK5x3J2KJb/2qVSKP2YJo9VlC3ritQ3kWMAs6ZLbx16eznVCG7Q2ZVpG%2BffSslQBWN0ivkAVZRISNLQWZBzJgPYVHk8ksIF4uRiVOV/a6x%2BaI8g/xHebooMuHR83fz7EiUDjCF%2B/9c/xhjg4CisuadDyVMdmVxnn11pFmJfv8vN5LDLDQrfdM75dqBKrCD9RyiyGQK9I6MJDW8pwGOqcB/rbeBQgsJWhCVrc5DDF/gNJzXXKPw9JoNOlBGaQt8CkF9/TbL0J8eutoUmNxUzvhBT1DUTQteTR//gR79LqvarM6gSf2ruoq5aJdErglZwzA8C/NL9ZxB3ccRmmd7nEIX4cO9oqyv9x3lKdQ209/LmdPnU49zGGoqg%2BNpoXFLmiDyLvYwOQUKfJ2c3THqjA48k47YGlFGISyRDKD01EM%2B98tPkXJRew=&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20221216T183631Z&X-Amz-SignedHeaders=host&X-Amz-Expires=899&X-Amz-Credential=ASIA2YR6PYW52M37CSLZ/20221216/us-west-2/s3/aws4_request&X-Amz-Signature=e7a40ce6105879c388c211d923e3a421fbcddb4273678b11fa2951e2b7648de3 "Scanner Files")
<a id="rus"></a>
# RUS Version
___Программа для расчета заливки файлов pdf макетов___

Программа была разработана для типографии, чтоб улучшить скорость для расчета заливки файлов pdf.
Сделана была на C# Windows Forms на паттерне:
MVVM — это паттерн разработки, позволяющий разделить приложение на три функциональные части:
Model — основная логика программы (работа с данными, вычисления, запросы и так далее)
View — вид или представление (пользовательский интерфейс)
ViewModel — модель представления, которая служит прослойкой между View и Model
Преимущество программы:
- Возможность выбрать несколько файлов для расчета заливки и сверяет с таблицей которую заранее скопировали;
- Сверяет размеры с таблицей;
- Находит битые и поврежденные страницы pdf.

# Демонстрационный видеоролик о программе 
___Нажмите на картинку для просмотра___
[![WATCH ME](https://upwork-usw2-prod-agora-file-storage.s3.us-west-2.amazonaws.com/profile/portfolio/thumbnail/2b2ada1b60d323a02feecd531482d901?response-content-disposition=inline;+filename=%22image_original%22;+filename*=utf-8%27%27image_original&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEOH//////////wEaCXVzLXdlc3QtMiJIMEYCIQCvfEzWoUmlPgFALhu5E8uu0A0WxoGF4LxPXBIJXsYdegIhANK/%2BoBKKgpT/mB91Gz7hCoeEUyQkSDERM/R2bcCUcz0Ks0ECBoQABoMNzM5OTM5MTczODE5Igwfp4tSu6ddtVpy02gqqgR/IPdov8P37uyO2%2BLPbtJ1qecdeQmGkMcm4xK7sxVzzYk%2BXQPbpHxgt/1duB1Iix679POy5chUeG5vfgFzd91N1mY%2Bt6OFEojdYu7JS/TawF7WpqTb0tF3FswRXidlsFgxSq5Knk7NsBtmrnBZmzvKQdYxoMb9jEMCxx1cS5G80gqK7awslgtW/ANxzLdvaOZv5jhIWWKPLY33X2xu/8oBmGjPx2529t1C5SnRPYIjS%2B9GljodoPIHHkzduMw%2BcgAiXlAIhLqNvKIpl6nrrUqBgpJl4V9CdQ5v6DpWn%2B%2BQLT4uUdIk2p%2BGwq30Wszu3hJuxtmYpXqKSS5rAF6Cg8SzO9JyZ9QaZWN/zEc4oz9K5ZXO4aFUYwbW2iIrFricESCQHyJRh7sEbKJnpdLfVgzoStKM5YAOaCxHCtWzOblXME47D%2Bh8jIUJANxMo8qhd8%2B3RtjpCNjHEeyodPJuVqxkuRZbBB7pTTYwKkBOeOWAfOJAc6P65oowZxjxino6dcuZI8qDRsrMRMHj2cEVC33v1x/U2MGfXWgj8vMZ/bbKYUSqrkm/yJdyaEZJwpZCuOM3wyj%2BsrexcCfZJ3kDXGSL2k6Ss55CeFjuxq9uiEVleRri8MyzTz3nKlyGjBeUIKkAwMZ3GPnzJM0ZJ8dT2VjPTe0pkOPnMZBlXmxpYkmgp6l6HVUpgJ0iC8mPE7Kk6hvRa2DbupzLkUl1y8cVbmepo2lXnqnohMrIOTDIxvKcBjqmAWYhEotraG625HGk03AU%2BUumOIKwuRqM2lFLH3bKFMJ6/dOoPpNxGrQbPQqGkjcurCng15w7CVhts6iika80eFkr0u2KfwbJ4q2BNIrFyDFrck7446W16065%2B7E/ef%2B9BE%2BvNH%2BoGGkZVyEkrqNa7NOB0sW1u5uBd04mtKSfCGQxptrM/qXxl1Goq%2Bfas6%2Bh4PHj2ThMpPbCsDcuP9%2BNv/MoyJg69QI=&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20221216T183429Z&X-Amz-SignedHeaders=host&X-Amz-Expires=900&X-Amz-Credential=ASIA2YR6PYW572LKKVMA/20221216/us-west-2/s3/aws4_request&X-Amz-Signature=29ced7d62dc4a8a1803f201683d32bbfec972d7476f4d290a377aba7bfcf3c90)](https://youtu.be/3JEToPbr6yw)
# Скриншоты(еще дополнятся)
___Интерфейс сканирования файлов___
![Alt text](https://upwork-usw2-prod-agora-file-storage.s3.us-west-2.amazonaws.com/profile/portfolio/thumbnail/2b2ada1b60d323a02feecd531482d901?response-content-disposition=inline;+filename=%22image_original%22;+filename*=utf-8%27%27image_original&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEOL//////////wEaCXVzLXdlc3QtMiJHMEUCIAzuLDc46wjhMrD/153uK9qJ9luvz5QeyBmS/rAvJcwgAiEAkqJ6w/G9qv5KRA2RwL/8CL6co1mnZ9ygMODShF%2BM2jsqzQQIGhAAGgw3Mzk5MzkxNzM4MTkiDDvRlDhKnkLAyago8CqqBG37K6ycm6cy3sJ8W/voQDBDx0irSr6YszABDK5ZZHI5TQCmowOCEiEsdH9Av4RukKwBGXh4gcMcAlwnLOAJuA0i9/tRfLdBB2AL5nm41r1uoWteHAuCu70sjsPZb3j2xwMURzzUtE6ZNzlMiEv0UMAz%2Bsb8Oh5RNPn0Jltm5fvYlLrRjRhXiRtnKdR/APppuwA14w0whgPc5mQxpOtvuSf6nw%2BqB/vzKDSaWYWAQ2XMqLxkwRUwk4025KK%2Bh4p/8QD9Vzt0lw%2BDf9/ozgxOrBUmjI6SiwRSqTnPgZFAs90jYFHK2zQ9Kinul9N80HIJOUNsmYjXP0L82llQ3R8hz8Cy%2BQBbDyCHkXFlhdIpe/7nELzDqrqx6l%2BHOPQ5WlR1WJwq%2BauomSqH9c%2B31eFCGolaZ8C5I1D/0OrTjjl7/oTV9LAYqlFm22%2BSgzMtrx%2BdAMr5s5%2BYHpCoqivOwX7JQ4/XGvPtj7K%2Bll2JIOBJItLOM4l92GSMBwjJDEQyqzvG7lX/fqV88NRTD6g0pQfb5gbIfvELK5x3J2KJb/2qVSKP2YJo9VlC3ritQ3kWMAs6ZLbx16eznVCG7Q2ZVpG%2BffSslQBWN0ivkAVZRISNLQWZBzJgPYVHk8ksIF4uRiVOV/a6x%2BaI8g/xHebooMuHR83fz7EiUDjCF%2B/9c/xhjg4CisuadDyVMdmVxnn11pFmJfv8vN5LDLDQrfdM75dqBKrCD9RyiyGQK9I6MJDW8pwGOqcB/rbeBQgsJWhCVrc5DDF/gNJzXXKPw9JoNOlBGaQt8CkF9/TbL0J8eutoUmNxUzvhBT1DUTQteTR//gR79LqvarM6gSf2ruoq5aJdErglZwzA8C/NL9ZxB3ccRmmd7nEIX4cO9oqyv9x3lKdQ209/LmdPnU49zGGoqg%2BNpoXFLmiDyLvYwOQUKfJ2c3THqjA48k47YGlFGISyRDKD01EM%2B98tPkXJRew=&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20221216T183631Z&X-Amz-SignedHeaders=host&X-Amz-Expires=899&X-Amz-Credential=ASIA2YR6PYW52M37CSLZ/20221216/us-west-2/s3/aws4_request&X-Amz-Signature=e7a40ce6105879c388c211d923e3a421fbcddb4273678b11fa2951e2b7648de3 "Сканирование файлов")