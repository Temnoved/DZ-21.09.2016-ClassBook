using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZClassBook
{
    class Program
    {
        enum eMenu { searToAuth = 1, sortToTitl, delToCost};
        static void Main(string[] args)
        {
            try
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////// Блок тестирования работоспособности методов //////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //тестовый массив объектов класса Book
                //Book[] bTestArr = { new Book(new Author("A", "a"), "TitA", 11.11f), new Book(new Author("B", "b"), "TitB", 22.22f),
                //                    new Book(new Author("C", "c"), "TitC", 33.33f), new Book(new Author("D", "d"), "TitD", 44.44f),
                //                    new Book(new Author("E", "e"), "TitE", 55.55f), new Book(new Author("F", "f"), "TitF", 66.66f),
                //                    new Book(new Author("G", "g"), "TitG", 77.77f), new Book(new Author("H", "h"), "TitH", 88.88f),
                //                    new Book(new Author("I", "i"), "TitI", 99.99f), new Book(new Author("J", "j"), "TitJ", 10.10f),};

                //тестовый массив объектов класса Book с переставленнымы элементами для тестирования сортировки по названию (Book.SearchBookToAutho())
                //Book[] bTestArr2 ={ new Book(new Author("A", "a"), "TitA", 11.11f), new Book(new Author("I", "i"), "TitI", 99.99f),
                //                    new Book(new Author("E", "e"), "TitE", 55.55f), new Book(new Author("D", "d"), "TitD", 44.44f),
                //                    new Book(new Author("C", "c"), "TitC", 33.33f), new Book(new Author("F", "f"), "TitF", 66.66f),
                //                    new Book(new Author("H", "h"), "TitH", 88.88f), new Book(new Author("G", "g"), "TitG", 77.77f),
                //                    new Book(new Author("B", "b"), "TitB", 22.22f), new Book(new Author("J", "j"), "TitJ", 10.10f),};


                //Book.SearchBookByAuthor("H", bTestArr);//проверка работоспособности поиска по фамилии автора

                //проверка работоспособности сортировки по названию
                //Book.ShowArr(bTestArr2);
                //Book.SortByTitle(bTestArr2);
                //Book.ShowArr(bTestArr2);

                //проверка работоспособности удаления по цене
                //Book.ShowArr(bTestArr);
                //Book.DeletByCost(55.55f, ref bTestArr);
                //Book.ShowArr(bTestArr);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                int iArrSize = 0;//для ввода раозмера массива

                do
                {

                    Console.Write("Enter the size of the array of books:");//просим ввести размер массива
                    iArrSize = Convert.ToInt32(Console.ReadLine());//вводим и преобразовываем ввод
                    if (iArrSize > 0 && iArrSize < int.MaxValue)//если размер отрицательный или слишком большой просим ввести еще раз
                        break;
                } while (true);

                Book[] boArr = new Book[iArrSize];//создаём массив введенного размера

                Book.EnterArr(ref boArr);//заполнение массива

                //начало работы меню
                do
                {
                    //предлагаемые действия
                    Console.WriteLine(new String('*', 75));
                    Console.WriteLine("1 - Search by author's name\n2 - Sort by book's title\n3 - Delet by book's cost\nAny other input - Exit ");
                    Console.Write("Select an action:");
                    eMenu eSelAct = (eMenu)Convert.ToInt32(Console.ReadLine());//ввод и преобразование выбора действия
                    switch (eSelAct)
                    {
                        //если выброн поиск по имени просим ввести имя и запускаем поиск
                        case eMenu.searToAuth:
                            Console.Write("Enter author's name(only Surname):");
                            Book.SearchBookByAuthor(Console.ReadLine(), boArr);
                            break;
                        //если выбрана сортировка запускаем сортировку и показываем результат на консоль
                        case eMenu.sortToTitl:
                            Book.SortByTitle(boArr);
                            Console.WriteLine("Sort List:");
                            Book.ShowArr(boArr);
                            break;
                        //если выбрано удаление по цене просим ввести цену и запускаем метод удаления
                        case eMenu.delToCost:
                            Console.Write("Enter book's cost(format XX,XX):");
                            float fCost = 0f;
                            if (!float.TryParse(Console.ReadLine(), out fCost))
                            {
                                Console.WriteLine("Error enter cost");
                            }
                            else
                            {
                                Book.DeletByCost(fCost, ref boArr);
                            }
                            break;
                        //при любом другом вводе завершаем программу
                        default:
                            return;                            
                    }
                } while (true) ;
            }//конец общего try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }//конец Main
    }//конец class Program
}//конец namespace DZClassBook
