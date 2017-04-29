# .NET.S.2017.01.Slizh.09
<h1>Task 1</h1>
<p>Разработать класс Book с 4-5 свойствами, переопределив для него необходимые методы класса Object. 
Для объектов класса реализовать отношения эквивалентности и порядка. Для выполнения основных операций со списком книг, 
который можно загрузить и, если возникнет необходимость, сохранить в некоторое хранилище BookListStorage.</p>
<p>Разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью:</p>
<p> - AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение); </p>
<p> - RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение); </p>
<p> - FindBookByTag (найти книгу по заданному критерию); </p>
<p> - SortBooksByTag (отсортировать список книг по заданному критерию).</p> 
<p> - Реализовать возможность логирования сообщений различного уровня. </p>
<p>Работу классов продемонстрировать на примере консольного приложения. </p>
<p>В качестве хранилища использовать
- двоичный файл, для работы с которым использовать только классы BinaryReader, BinaryWriter. 
- двоичный файл, для работы с которым использовать двоичный сериализатор;
- XML-файл (любая технология без ограничений).</p>
