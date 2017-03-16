using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Program
    {
        static int choice;

        public class Book
        {
            public int bookId;
            public string bookName;
            public int bookprice;
            public int count;
        }
        class BorrowDetails
        {
            public string userName;
            public DateTime borrowDate;
            public int borrowCount;
        }

        public static List<Book> bookList = new List<Book>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        //SEARCH ISSUE SUBMIT EXIT
        public static void Main(string[] args)
        {
            bookList.Add(new Book { bookId = 1, bookName = "c#", bookprice=300, count = 5 });
            bookList.Add(new Book { bookId = 2, bookName = "java", bookprice = 400, count = 5 });
            bookList.Add(new Book { bookId = 3, bookName = "crm", bookprice = 350, count = 5 });
            bookList.Add(new Book { bookId = 4, bookName = "php", bookprice = 450, count = 5 });
            SelectOption();
        }

        public static void searchBook(string bookName)
        {
          if(bookList.Exists(c => (c.bookName == bookName)))
            {
                Console.WriteLine("\nBook Found!\n");
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookName == bookName)
                    {
                        Console.WriteLine(
                        "Book id :{0}\n" +
                        "Book name :{1}\n" + 
                        "Book count:{2}\n",
                        searchId.bookId, searchId.bookName, searchId.count);
                    }                    
                }
            }
            else
                Console.WriteLine("\nBook Not Found!\n");
            SelectOption();
        }

        public static void IssueBook(int bookID)
        {
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.Write("User Name :");

            borrow.userName = Console.ReadLine();
            
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());
            Console.WriteLine("\nChecking if specified books exist...\n");
            if (bookList.Exists(x => x.bookId == bookID))
            {
                Book requiredBook = bookList.Find(x => x.bookId == bookID);
                if (borrow.borrowCount <= requiredBook.count)
                {                  
                    Console.WriteLine("Book Issued");
                    requiredBook.count = requiredBook.count - borrow.borrowCount;
                   // borrow.borrowCount++;
                }
                else
                    Console.WriteLine("Sorry, there are only " + requiredBook.count + " books in stock!");
            }
            else
                Console.WriteLine("Book with the given ID does not exist");
        }

        public static void SubmitBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details :");

            Console.Write("Book id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());

            if (bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book ReturnBookCount in bookList)
                {
                    if (ReturnBookCount.bookId == returnId)
                    {
                        ReturnBookCount.count = ReturnBookCount.count + returnCount;
                        Console.WriteLine("Book Submitted!");
                        break;
                    }
                    //else
                    //{
                    //    Console.WriteLine("Count exceeds the actual count");
                    //    break;
                    //}
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }

        public static void SelectOption()
        {
            Console.WriteLine("\n 1 - Search \n 2 - Issue \n 3 - Submit \n 4 - Exit");
            Console.WriteLine("\nEnter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nEnter the name of the book that you want to search: ");
                    string searchString = Console.ReadLine();
                    searchBook(searchString);
                    break;
                case 2:
                    Console.WriteLine("\nEnter the ID of the book that you want to issue");
                    int bookID = Convert.ToInt16(Console.ReadLine());
                    IssueBook(bookID);
                    SelectOption();
                    Console.ReadLine();
                    break;
                case 3:
                    SubmitBook();
                    SelectOption();
                    Console.ReadLine();
                    break;
                case 4:                    
                    break;
                default:
                    Console.WriteLine("\nEnter Valid Input");
                    Console.ReadLine();
                    SelectOption();
                    break;
            }
        }
    }
}
