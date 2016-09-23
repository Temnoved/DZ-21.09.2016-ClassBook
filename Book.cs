using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZClassBook
{
    struct Author//структура с данными автора
    {
        public String strSurname;
        public String strFirstname;

        public Author(String strSur = "", String strFirst = "")
        {
            strSurname = strSur;
            strFirstname = strFirst;
        }
    };

    class Book
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////// поля //////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        protected Author bookAuthor = new Author();
        protected String strTitle = "";
        protected float fCost = 0f;

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////// методы ////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        //конструктор с параметрами по умолчанию
        public Book(Author auAu = new Author(), String strTit = "", float fCos = 0f)
        {
            this.bookAuthor = auAu;
            this.strTitle = strTit;
            this.fCost = fCos;
        }

        public String AuthorFirstname
        {
            set { this.bookAuthor.strFirstname = value; }//установка имени автора
        }

        public String AuthorSurname
        {
            set { this.bookAuthor.strSurname = value; }//установка фамилии автора
        }

        public Author AuthorData
        {
            set { this.bookAuthor = value; }
        }

        public String BookTitle
        {
            set { this.strTitle = value; }//установка названия книги
        }

        public float BookCost
        {
            set { this.fCost = (float)value; }//установка установка стоимости
        }

        static public void EnterArr(ref Book [] boArr)//метод заполнения массива
        {
            for (int i = 0; i < boArr.Length; i++)
            {
                Console.Write("Enter author surname:");
                String strSur = Console.ReadLine();
                Console.Write("Enter author firstname:");
                String strFir = Console.ReadLine();
                Console.Write("Enter title of the book:");
                String strTit = Console.ReadLine();
                Console.Write("Enter cost the book(format XX,XX):");
                float fCost = 0f;

                if (!float.TryParse(Console.ReadLine(), out fCost))
                {
                    Console.WriteLine("Error enter cost");
                }
                else
                {
                    boArr[i] = new Book(new Author(strSur, strFir), strTit, (float)fCost);
                }
            }
        }

        public void ShowBookInfo()//метод вывода информации о книге на консоль
        {
            Console.WriteLine(new String('*', 30) + " Book info " + new String('*', 30));
            Console.WriteLine("Surname: {0}\nFirstname: {1}\nTitle: {2}\nCost: {3}",
                              this.bookAuthor.strSurname, this.bookAuthor.strFirstname, this.strTitle, this.fCost.ToString());
            Console.WriteLine(new String('*', 71));
        }

        //поиск книги по фамилии автора
        static public void SearchBookByAuthor(String strSearchName, Book[] boArr)
		{
			foreach(Book i in boArr)
			{
				if(i.bookAuthor.strSurname == strSearchName)
				{
					i.ShowBookInfo();
				}
            }
		}
		
		static public void SortByTitle(Book[] boArr)//сортировка книг по названию
		{
            Array.Sort(boArr, (a, b) => { return String.Compare(a.strTitle, b.strTitle);});//сортировка массива через сравнение строк
		}
		
        //удаление из массива по цене
		static public void DeletByCost(float fCos, ref Book[] boArr)
        {
            //ищем книги с соответствующей ценой
            for (int i = 0; i < boArr.Length; i++)
            {
                if (boArr[i].fCost == fCos)//если находим
                {
                    Book [] bTemp = new Book[boArr.Length - 1];//создаём временный массив меньше основного
                    Array.Copy(boArr, 0, bTemp, 0, i);//копируем элементы до удаляемого
                    Array.Copy(boArr, i + 1, bTemp, i, boArr.Length - i - 1);//копируем элементы после удаляемого
                    boArr = bTemp;//основной массив теперь равен временному
                    i--;//уменьшаем индекс для проверки элемента сдвинувшегося справа на лево
                }
            }
        }
        
        static public void ShowArr(Book [] bArr)//показ названий книг всего массива на консоли
        {
            foreach(Book i in bArr)
            {
                Console.Write(i.strTitle + " ");
            }
            Console.WriteLine();
        }		
    }//конец class Book
}//конец namespace DZClassBook
