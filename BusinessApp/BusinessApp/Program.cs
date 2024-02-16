using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
namespace BusinessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrsize = 100;

            // parallel arrays for signing up the users
            string[] Username = new string[100];
            string[] uPassword = new string[100];
            string[] role = new string[100];
            int customercount = 0;
            int usercount = 0;
            int loginoption = 0;
            int usercountforCus = 100; float price = 0f;
            int[] signIncount = new int[100];
            // parallel arrays for the functionalities of user
            string[] nameOfUser = new string[100]; string[] country = new string[100]; string[] ID = new string[100]; string[] leg = new string[100]; string[] food = new string[100];
            string[] date = new string[100];
            string[] departure = new string[100]; string[] arrival = new string[100];
            string[] genderOfUser = new string[100];
            string[] ageofuser = new string[100];
            string[] clas = new string[100]; string[] customerreviews = new string[100];
            int logincount = 0;
            int totalrevenue = 0;
            // parallel arrays for the functionalities of owner
            string[] employee = new string[100];
            string[] IDNum = new string[100];
            string[] airline = new string[100];
            string[] aircode = new string[100];
            int aircount = 0;
            string[] usernameForEmployee = new string[100];
            int logincount1 = 0;
            int[] budgetforCus = new int[100];
            bool budgetresult=false;
            int count;
            string[] dayOfDeparture = new string[100];
            string airlineChoice;
            int ticketprice = 0;
            int business = 0, legspace = 0, foodservice = 0;
            int salary=0;
            int discountcount = 10;
            string[] discountonTicket = new string[100];
            int dayscountOfDiscount=0;
            string resultofDiscount;
            float discountPercetage = 0f;
            bool discountavail=false;
            string[] selectedairline = new string[100];

            string announcement="";
            int cancelledTickets;
            float result1=0f;
            int budgetforCustomer=0;
            // parallel arrays for functionalities of employees
            string[] arrivalcount = new string[100];
            string[] departurecount = new string[100];
            int countOfDeparture = 0;
            int countOfArrival = 0;
            int cancelcount = 0;

            Console.Clear();
            printaAeroplane();
            Loading();

            while (true)
            { // loop for signinng in and out


                printscreen();
                loginmenu();

                subMenuBeforeMainMenu("login");
                string call1 = "";
                string call = login(call1);
                if (call == "1")
                {
                    // cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    printscreen();
                    signininterface();
                    string name;
                    string password;
                    string Roles;
                    Console.WriteLine("Sign In Menu");
                    while (true)
                    {

                        Console.WriteLine("Enter the username:");

                        name = Console.ReadLine();
                        if (checkeEmpty(name) == true)
                        {

                            Console.WriteLine("Invalid input.");

                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {

                        Console.WriteLine("Enter the password(must be 8): ");
                        password = Console.ReadLine();
                        if (checkeEmpty(password) == true  || check_number(password, 8) == true )
                        {

                            Console.WriteLine("Invalid input. ");

                        }
                        else
                        {
                            break;
                        }
                    }

                    Roles = signIn(name, password, Username, uPassword, role, usercount);

                    if (Roles == "user" || Roles == "User" || Roles == "Customer" || Roles == "customer")
                    { // loop for the functionalaities of user


                        readLogincount(ref logincount);
                        if (checkSignInAgain(name, ref customercount, nameOfUser, country, genderOfUser, ageofuser, departure, arrival, leg, food, date, dayOfDeparture, ID, clas, selectedairline, customerreviews))
                        {
                            outputAgain(nameOfUser, country, genderOfUser, ageofuser, departure, arrival, leg, food, date, dayOfDeparture, ID, clas, selectedairline, customerreviews, customercount);
                            Console.Read();
                        }

                        else
                        {
                            while (true)
                            {
                                printscreen();
                                customerMenu();
                                Console.WriteLine(subMenuBeforeMainMenu("User"));
                                string op = "";
                                string result = menu(op);
                                if (result == "1")
                                {
                                    printscreen();
                                    viewShedule(arrivalcount, departurecount, ref countOfDeparture, ref countOfArrival);
                                    clearscreen();
                                }
                                else if (result == "3")
                                {
                                    printscreen();
                                    personalInformation(nameOfUser, country, ID, genderOfUser, ageofuser, logincount);
                                    clearscreen();
                                }
                                else if (result == "4")
                                {
                                    printscreen();
                                    flightInformation(arrival, departure, date, dayOfDeparture, logincount, departurecount, arrivalcount, countOfDeparture, countOfArrival);
                                    clearscreen();
                                }
                                else if (result == "5")
                                {
                                    printscreen();
                                    InflightServices(leg, food, logincount);
                                    clearscreen();
                                }
                                else if (result == "6")
                                {
                                    printscreen();
                                    classSelection(clas, logincount);
                                    clearscreen();
                                }
                                else if (result == "7")
                                {
                                    printscreen();

                                    readExtraCharges(ref business, ref legspace, ref foodservice);
                                    printBudgetRequirements(leg, food, logincount, totalrevenue,ref ticketprice, clas, business, legspace, foodservice);
                                    readDiscountPercentage(ref discountPercetage);

                                    clearscreen();
                                }
                                else if (result == "8")
                                {

                                    printscreen();
                                    string CheckForResult;
                                    while (true)
                                    {

                                        Console.Write("Enter your budget: ");

                                        CheckForResult = Console.ReadLine();
                                        if (checkeEmpty(CheckForResult) == true || check_int(CheckForResult) == true)
                                        {

                                            Console.WriteLine("Invalid input.");

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    budgetforCustomer = int.Parse(CheckForResult);

                                    int priceOfticket = cal1(leg, food, logincount, totalrevenue, ticketprice, clas, business, legspace, foodservice);

                                    budgetresult = budget(priceOfticket, budgetforCustomer);
                                    if (budgetresult == true)
                                    {

                                        Console.WriteLine("The budget is enough.");

                                    }
                                    else
                                    {

                                        Console.WriteLine("The budget is not enough.");

                                    }

                                    clearscreen();
                                }
                                else if (result == "11")
                                {
                                    printscreen();
                                    reviews(customerreviews, logincount);
                                    clearscreen();
                                }
                                else if (result == "9")
                                {
                                    string check_for_result;
                                    printscreen();
                                    int airlinechoice;
                                    availableAirline(airline,ref aircount);
                                    ;
                                    while (true)
                                    {
                                        Console.WriteLine("Select your choice:");
                                        ;
                                        // cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                                        check_for_result = Console.ReadLine();
                                        if (checkeEmpty(check_for_result) == true || check_int(check_for_result) == true)
                                        {

                                            Console.WriteLine("Invalid input.");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    airlinechoice = int.Parse((check_for_result));
                                    selectairline(airline, airlinechoice, aircount, selectedairline, logincount);

                                    clearscreen();
                                }
                                else if (result == "2")
                                {
                                    printscreen();
                                    viewDiscountOptions(discountonTicket, dayscountOfDiscount);

                                    clearscreen();
                                }
                                else if (result == "10")
                                {
                                    printscreen();
                                    price = cal1(leg, food, logincount, totalrevenue, ticketprice, clas, business, legspace, foodservice);
                                    discountavail = isDiscountAvailable(dayOfDeparture, logincount, dayscountOfDiscount, discountonTicket);
                                    if (discountavail == true)
                                    {
                                        result1 = discountedvalue(ref price, discountPercetage);
                                        
                                        Console.WriteLine("The total price after discount is: " + result1);

                                        readTotalrevenue(ref totalrevenue);
                                        float v = totalrevenue + result1;
                                        totalrevenue = (int)v;
                                        totalrevenueData(totalrevenue);
                                    }
                                    else
                                    {

                                        Console.WriteLine("The total price is: " + price);

                                        readTotalrevenue(ref totalrevenue);
                                        totalrevenue = (int)(totalrevenue + price);
                                        totalrevenueData(totalrevenue);
                                    }
                                    clearscreen();
                                    totalprice(totalrevenue);
                                }

                                else if (result == "12")
                                {
                                    printscreen();

                                    if (budgetresult == true)
                                    {
                                        if (discountavail == true)
                                        {
                                            output(nameOfUser, departure, arrival, leg, food, clas, date, ID, result1, logincount, customerreviews, genderOfUser, ageofuser, country, budgetresult, dayOfDeparture, discountavail, selectedairline, ticketprice, budgetforCustomer);
                                        }
                                        else
                                        {
                                            output(nameOfUser, departure, arrival, leg, food, clas, date, ID, price, logincount, customerreviews, genderOfUser, ageofuser, country, budgetresult, dayOfDeparture, discountavail, selectedairline, ticketprice, budgetforCustomer);
                                        }
                                    }
                                    else
                                    {

                                        Console.WriteLine("Your ticket has not confirmed.");

                                    }
                                    clearscreen();
                                }

                                else if (result == "13")
                                {
                                    if (cancelcount > 0)
                                    {
                                        Console.WriteLine("You have already cancelled the ticket.");
                                        clearscreen();
                                    }
                                    else
                                    {
                                        if (isDiscountAvailable(dayOfDeparture, logincount, dayscountOfDiscount, discountonTicket))

                                        {
                                            cancelllationOfTicket(nameOfUser, ID, genderOfUser,ref totalrevenue, ageofuser, departure, arrival, leg, food, clas, date, dayOfDeparture,ref result1, customerreviews, logincount, selectedairline);
                                            totalrevenue = (int)(totalrevenue - result1);
                                            result1 = 0;
                                            totalrevenueData(totalrevenue);
                                        }
                                        else
                                        {
                                            cancelllationOfTicket(nameOfUser, ID, genderOfUser,ref totalrevenue, ageofuser, departure, arrival, leg, food, clas, date, dayOfDeparture,ref price, customerreviews, logincount, selectedairline);
                                            totalrevenue = (int)(totalrevenue - price);
                                            price = 0;
                                            totalrevenueData(totalrevenue);
                                        }
                                    }

                                    cancelTicketMessage();
                                    clearscreen();
                                    cancelcount++;
                                }
                                else if (result == "14")
                                {
                                    signIncount[logincount] = 1;
                                    if (isDiscountAvailable(dayOfDeparture, logincount, dayscountOfDiscount, discountonTicket))
                                    {
                                        storeUserData(name, nameOfUser, country, genderOfUser, ageofuser, departure, arrival, leg, food, date, dayOfDeparture, ID, result1, clas, selectedairline, customerreviews, logincount, signIncount);
                                    }
                                    else
                                    {
                                        storeUserData(name, nameOfUser, country, genderOfUser, ageofuser, departure, arrival, leg, food, date, dayOfDeparture, ID, price, clas, selectedairline, customerreviews, logincount, signIncount);
                                    }
                                    if (cancelcount == 1)
                                    {
                                        logincount = logincount;
                                    }
                                    else
                                    {
                                        logincount++;
                                    }

                                    addTickestCount(logincount);
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Invalid option: ");

                                    clearscreen();
                                }
                            }
                        }
                    }
                    else if (Roles == "Owner" || Roles == "owner" || Roles == "admin" || Roles == "Admin")
                    { // loop for the functionalities of admin

                        while (true)
                        {
                            printscreen();
                            adminMenu();
                            subMenuBeforeMainMenu("Owner");
                            string op="";
                            string choice = OwnerInterface(op);
                            if (choice == "1")
                            {
                                // cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                                Console.Clear();
                                printHeader();
                                string name1;
                                string ID1;
                                string var;
                                while (true)
                                {

                                    Console.Write("Enter the name: ");

                                    name1 = Console.ReadLine();
                                    if (checkeEmpty(name1) == true|| checkstring(name1) == true)
                                    {

                                        Console.WriteLine("Invalid input.");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                while (true)
                                {

                                    Console.WriteLine("Enter the ID(must be 13 integers): ");

                                    ID1 = Console.ReadLine();
                                    if (check_int(ID1) == true || check_number(ID1, 13) == true)
                                    {

                                        Console.WriteLine("Invalid input.");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                while (true)
                                {
                                    ;
                                    Console.WriteLine("Enter the username you want to allocate to employee: ");
                                    ;

                                    var = Console.ReadLine();
                                    if (checkeEmpty(var) == true)
                                    {
                                        ;
                                        Console.WriteLine("Invalid input. ");
                                        ;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (Addemployee(name, ID1, employee, IDNum,ref  logincount1, var, usernameForEmployee))
                                {

                                    Console.WriteLine("Employee added sucessfully");

                                }
                                else
                                {

                                    Console.WriteLine("Username or ID alredy present");

                                }

                                clearscreen();
                            }
                            else if (choice == "2")
                            {
                                // cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                                printscreen();
                                string removingEmployee;

                                while (true)
                                {
                                    Console.WriteLine("Enter the Username of employee you want to remove: ");

                                    removingEmployee = Console.ReadLine();
                                    if (checkeEmpty(removingEmployee) == true)
                                    {

                                        Console.WriteLine("Invalid input. ");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (removeEmployee(removingEmployee, employee, IDNum, ref logincount1, usernameForEmployee))
                                {

                                    Console.WriteLine("Employee removed sucessfully");

                                }
                                else
                                {

                                    Console.WriteLine("Employee not found.");

                                }
                                clearscreen();
                            }
                            else if (choice == "12")
                            {
                                printscreen();

                                readTotalrevenue(ref totalrevenue);
                                Console.WriteLine("The total revenue generated is : " + totalrevenue);

                                clearscreen();
                            }
                            else if (choice == "3")
                            {
                                printscreen();
                                addAirline(airline, aircode,ref aircount);
                                clearscreen();
                            }
                            else if (choice == "11")
                            {
                                printscreen();

                                
                                readLogincount(ref logincount);
                                customerReviews(customerreviews, logincount);
                                clearscreen();
                            }
                            else if (choice == "4")
                            {
                                printscreen();
                                employeeList(employee, IDNum, usernameForEmployee, ref logincount1);
                                clearscreen();
                            }
                            else if (choice == "5")
                            {
                                printscreen();
                                pricealloaction(ref ticketprice);
                                clearscreen();
                            }
                            else if (choice == "6")
                            {
                                printscreen();
                                extraCharges(ref business,ref legspace,ref foodservice);
                                clearscreen();
                            }
                            else if (choice == "7")
                            {
                                printscreen();
                                salaryfixation(ref salary);

                                Console.WriteLine("Select the employee whose salary you want to pay:");

                                salarymanagement(employee, logincount1,ref totalrevenue, IDNum, salary);
                                clearscreen();
                            }
                            else if (choice == "8")
                            {
                                printscreen();
                                discount(discountonTicket,ref dayscountOfDiscount);
                                clearscreen();
                            }
                            else if (choice == "9")
                            {
                                printscreen();

                                Console.WriteLine("Enter the percentage of discount you want to give:");

                                percentageOfDiscount(ref discountPercetage);
                                clearscreen();
                            }
                            else if (choice == "10")
                            {
                                printscreen();
                                announcementToEmployee(ref announcement);
                                clearscreen();
                            }
                            else if (choice == "13")
                            {
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Invalid option.");

                                clearscreen();
                            }
                        }
                    }
                    else if (Roles == "employee" || Roles == "Employee" || Roles == "manager" || Roles == "Manager")
                    {

                        // loop for the functionalities of employee
                        while (true)
                        {
                            printscreen();
                            managerMenu();
                            string op="";
                            string choice1 = Employeeinterface(op);
                            if (choice1 == "1")
                            {
                                printscreen();
                                shedule(departurecount, arrivalcount,ref countOfDeparture,ref countOfArrival);
                            }
                            else if (choice1 == "2")
                            {
                                printscreen();

                                readLogincount(ref logincount);
                                Console.WriteLine("There have been " + ticketscount(logincount) + " tickest sold today.");


                                clearscreen();
                            }
                            else if (choice1 == "3")
                            {
                                printscreen();
                                viewselectedAirlines(selectedairline, logincount);
                                clearscreen();
                            }
                            else if (choice1 == "4")
                            {
                                printscreen();
                                viewselectedServices(leg, food, clas, logincount);
                                clearscreen();
                            }
                            else if (choice1 == "5")
                            {
                                printscreen();
                                profitandLoss(ref totalrevenue);
                                clearscreen();
                            }
                            else if (choice1 == "6")
                            {
                                printscreen();
                                viewAnnouncements(announcement);
                                clearscreen();
                            }
                            else if (choice1 == "7")
                            {
                                printscreen();
                                viewCustomerInformation(nameOfUser, ID, country, genderOfUser, ageofuser, arrival, departure, date, dayOfDeparture, logincount);
                                clearscreen();
                            }
                            else if (choice1 == "8")
                            {
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Invalid option.");

                                clearscreen();
                            }
                        }
                    }
                    else
                    {

                        Console.WriteLine("Undefined");

                        clearscreen();
                    }
                }

                else if (call == "2")
                { // loop for signing up users

                    // cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    printscreen();
                    signUpinterface();

                    Console.WriteLine(subMenuBeforeMainMenu("SignUp"));
                    Console.WriteLine("*.......................*");
                    
                    string name;
                    string password;
                    string roles="";
                    while (true)
                    {
                        Console.Write("Enter the username: ");
                        name = Console.ReadLine();
                        if (checkeEmpty(name) == true )
                        {

                            Console.WriteLine("Invalid input.");

                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true)
                    {

                        Console.WriteLine("Enter the password(must be 8 characters): ");

                        password = Console.ReadLine();
                        if (checkeEmpty(password) == true || checkSpace(password)==true || check_number(password, 8)==true || checkSpaces(password) == true)
                        {

                            Console.WriteLine("Invalid input. ");

                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        
                        Console.Write("Enter your role(admin,customer,manager): ");
                        
                        roles = Console.ReadLine();
                        if (checkeEmpty(roles) == true || checkstring(roles) == true || checkSpaces(roles) == true || checkRoles(roles) == true)
                        {
                            
                            Console.WriteLine("Invalid input.");
                            
                        }
                        else
                        {
                            break;
                        }
                    }

                    bool isTrue = signUp(name, password, roles, Username, uPassword, role,ref usercount, arrsize);

                    if (isTrue)
                    {

                        Console.WriteLine("Signed up succesfully");

                    }
                    if (!isTrue)
                    {

                        Console.WriteLine("Not signed up successfully");

                    }
                    clearscreen();
                }
                else if (call == "3")
                {

                    Console.Clear();
                    break;
                }

                else
                {

                    Console.WriteLine("Invalid option: ");

                    clearscreen();
                }
            }

        }
        static void readExtraCharges(ref int clas, ref int leg, ref int food)
        { string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\ExtraCharges.txt";
            StreamReader file=new StreamReader(path);
            
            string var;
             var = file.ReadLine();
            leg = int.Parse((getField(var, 1)));
            food = int.Parse(getField(var, 2));
            clas = int.Parse(getField(var, 3));
            file.Close();
        }
        static void readLogincount(ref int logincount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TicketsData.txt";
            StreamReader file=new StreamReader(path);
            
             logincount=int.Parse(file.ReadLine());
            file.Close();
        }
        static void cancelTicketMessage()
        {
            Console.WriteLine("If you want to book the ticket again fill out the above options again otherwise you will not be able to book the ticket.");
        }

        static void printBudgetRequirements(string[] leg, string[] food, int logincount, int totalrevenue, ref int ticketprice, string[] clas, int business, int legspace, int foodservice)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\addPrice.txt";
            StreamReader file=new StreamReader(path);
            
             ticketprice=int.Parse(file.ReadLine());
            file.Close();

            Console.WriteLine("Your budget should be greater than $" + cal1(leg, food, logincount, totalrevenue, ticketprice, clas, business, legspace, foodservice));

        }
        static void printHeader()

        { // function for printing header


            Console.WriteLine("                             |                              ");

            Console.WriteLine("  ____  _           __        ___                                                ");

            Console.WriteLine(" |");

            Console.WriteLine("                             |                              ");

            Console.WriteLine(" / ___|| | ___   _  \\ \\      / (_)_ __   __ _ ___                                ");

            Console.WriteLine(" |");

            Console.WriteLine("                             |                              ");

            Console.WriteLine(" \\___ \\| |/ / | | |  \\ \\ /\\ / /| | '_ \\ / _` / __|                               ");

            Console.WriteLine(" |");

            Console.WriteLine("                           .-'-.                            ");

            Console.WriteLine("  ___) |   <| |_| |   \\\\ V V / | | | | | (_| \\__ \\                              ");

            Console.WriteLine(".-'-.");

            Console.WriteLine("                          ' ___ '                           ");

            Console.WriteLine(" |____/|_|\\_\\__,  |    \\_/\\_/  |_|_| |_|\\__, |___/                             ");

            Console.WriteLine("' ___ '");

            Console.WriteLine("                ---------'  .-.  '---------                 ");

            Console.WriteLine("             _|___/                       |___/                      ");

            Console.WriteLine("---------'  .-.  '---------");

            Console.WriteLine("_________________________'  '-'  '_________________________ ");

            Console.WriteLine("            / \\  (_)_ __| (_)_ __   ___  ___        ");

            Console.WriteLine(" _________________________'  '-'  '_________________________");
            ;
            Console.WriteLine(" ''''''-|---|--/    \\==][^',_m_,'^][==/    \\--|---|-''''''");
            ;
            Console.WriteLine("             / _ \\ | | '__| | | '_ \\ / _ \\/ __|         ");
            ;
            Console.WriteLine("''''''-|---|--/    \\==][^',_m_,'^][==/    \\--|---|-''''''");
            ;
            Console.WriteLine("               \\    /  ||/   H   \\||  \\    /             ");
            ;
            Console.WriteLine("             / ___ \\| | |  | | | | | |  __/\\__ \\                       ");
            ;
            Console.WriteLine("\\    /  ||/   H   \\||  \\    /");
            ;
            Console.WriteLine("                '--'   OO   O|O   OO   '--'                 ");
            ;
            Console.WriteLine("         /_/   \\_\\_|_|  |_|_|_| |_|\\___||___/                       ");
            ;
            Console.WriteLine(" '--'   OO   O|O   OO   '--'");


        }

        static string menu(string op)
        { // function for printing the menu of user

            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            Console.WriteLine("\t\t\t\t\t\tSelect one of the following option: ");
            Console.WriteLine("\t\t\t\t\t\t1. View the shedule:");
            Console.WriteLine("\t\t\t\t\t\t2. View the days in which discount is available: ");
            Console.WriteLine("\t\t\t\t\t\t3. Add personal information: ");
            Console.WriteLine("\t\t\t\t\t\t4. Ticket booking:");
            Console.WriteLine("\t\t\t\t\t\t5. In fligth Services:");
            Console.WriteLine("\t\t\t\t\t\t6. Class Selection: ");
            Console.WriteLine("\t\t\t\t\t\t7. View budget requirements:");
            Console.WriteLine("\t\t\t\t\t\t8. Enter your budget:");
            Console.WriteLine("\t\t\t\t\t\t9. View Available Airlines");
            Console.WriteLine("\t\t\t\t\t\t10. View the price: ");
            Console.WriteLine("\t\t\t\t\t\t11. Reviews:");
            Console.WriteLine("\t\t\t\t\t\t12. Ticket reciept: ");
            Console.WriteLine("\t\t\t\t\t\t13. Cancel the ticket:");
            Console.WriteLine("\t\t\t\t\t\t14. logout");

            Console.WriteLine("\t\t\t\t\t\tYour option: ");

            op = Console.ReadLine();
            return op;
        }
        static string getField(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < record.Count(); x++)
            {
                if (record[x] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData(string[] names, string[] passwords, string[] roles, ref int idx)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Newfile.txt";
            string record;
            StreamReader data = new StreamReader(path);
            
            while ((record=data.ReadLine())!=null)
            {
               
                names[idx] = getField(record, 1);
                passwords[idx] = getField(record, 2);
                roles[idx] = getField(record, 3);

                idx = idx + 1;
            }
        }
        static string login(string login)

        {
            // function for login



            Console.WriteLine("\t\t\t\t\t\t1. Sign In: ");

            Console.WriteLine("\t\t\t\t\t\t2. Sign Up: ");
            Console.WriteLine("\t\t\t\t\t\t3. Exit: ");

            Console.WriteLine("\t\t\t\t\t\tEnter your choice within the given options: ");
            login = Console.ReadLine();
            return login;
        }
        static bool signUp(string name, string password, string role, string[] users, string[] passwords, string[] roles, ref int usersCount, int userArrSize)
        { // function for signUp
            Console.Clear();
            printHeader();
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Newfile.txt";
            StreamReader file=new StreamReader(path);
            
            string var;

            bool isFound = false;
            int x = 0;
            while ((var=file.ReadLine())!=null)
            {
                
                users[x] = getField(var, 1);
                passwords[x] = getField(var, 2);
                roles[x] = getField(var, 3);
                if ((role == "Owner" || role == "owner" || role == "Admin" || role == "admin") && (roles[x] == "owner" || roles[x] == "Owner" || roles[x] == "admin" || roles[x] == "Admin") || ((role == "Employee" || role == "employee" || role == "manager" || role == "Manager") && (roles[x] == "employee" || roles[x] == "Employee" || roles[x] == "Manager" || roles[x] == "manager")))
                {
                    isFound = true;
                    break;
                }
                x++;
            }

            for (int index = 0; index < x; index++)
            {
                if (name == users[index] && password == passwords[index])
                {

                    isFound = true;
                    break;
                }
            }
            if (isFound == true)
            {
                return false;
            }
            else if (usersCount < userArrSize)
            {

                readDataForSignUp(name, password, role, ref usersCount);

                usersCount++;
                return true;
            }

            else
            {
                return false;
            }
        }
        static void readDataForSignUp(string name, string password, string role, ref int usersCount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Newfile.txt";
            StreamWriter file=new StreamWriter(path,true);

            
            file .Write( name + ",");
             file .Write( password + ",");
            file .WriteLine(role );
            usersCount++;
            file.Close();
        }
        static string signIn(string name, string password, string[] users, string[] passwords, string[] roles, int usersCount)

        {
            // function for SignIn

            readData(users, passwords, roles, ref usersCount);

            for (int x = 0; x < usersCount; x++)
            {
                if (name == users[x] && password == passwords[x])
                {

                    return roles[x];

                    break;
                }
            }

            return "Wrong information";
        }

        static void viewShedule(string[] arrival, string[] departure, ref int departurecount, ref int arrivalcount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Daysdata.txt";
            StreamReader line=new StreamReader(path);
            string var1;
          
             var1=line.ReadLine();
            departurecount = int.Parse((getField(var1, 1)));
            arrivalcount = int.Parse((getField(var1, 2)));
            line.Close();
            Console.WriteLine("Arrival places: ");
            string path1 = "E:\\Semester 2\\Lab 1\\BusinessApp\\SheduleData.txt";
            StreamReader file=new StreamReader(path1);
            
            string var;
             var=file.ReadLine();

            for (int index = 0; index < arrivalcount; index++)
            {
                arrival[index] = getField(var, index + 1);
                Console.Write(arrival[index]);
            }
            Console.WriteLine("Departure places: ");
             var=file.ReadLine();
            for (int x = 0; x < departurecount; x++)
            {
                departure[x] = getField(var, x + 1);
                Console.Write(departure[x]);
            }
            file.Close();
        }

        static void output(string[] Name, string[] departure, string[] arrival, string[] legspace, string[] extrafood, string[] clas, string[] Date, string[] ID, float price, int logincount, string[] reviews, string[] gender, string[] age, string[] country, bool budgetresult, string[] dayofdeparture, bool discountavail, string[] airline, int ticketprice, int budgetforCustomer)
        {
            string discountavailability = "";

            string resultOfBudget = "Fligth status is OK. ";


            // function for printing the ticket receipt
            if (discountavail == true)
            {

                discountavailability = "You have availed the discount.";

            }

            if (discountavail == false)
            {

                discountavailability = "You have not availed the discount.";

            }

            if (price == 0)
            {

                Console.WriteLine("\t\t\t\t\t\tYou have not booked the ticket.");

            }
            else
            {

                Console.WriteLine("\t\t\t\t\t\t" + Name[logincount]);
                Console.WriteLine("\t\t\t\t\t\t" + country[logincount]);
                Console.WriteLine("\t\t\t\t\t\t" + gender[logincount]);
                Console.WriteLine("\t\t\t\t\t\t" + age[logincount]);
                Console.WriteLine("\t\t\t\t\t\tDeparture: " + departure[logincount]);
                Console.WriteLine("\t\t\t\t\t\tArrival: " + arrival[logincount]);
                Console.WriteLine("\t\t\t\t\t\tServices:");
                Console.WriteLine("\t\t\t\t\t\tLeg Space: " + legspace[logincount]);
                Console.WriteLine("\t\t\t\t\t\tFood Service: " + extrafood[logincount]);
                Console.WriteLine("\t\t\t\t\t\tDate of Departure: " + Date[logincount]);
                Console.WriteLine("\t\t\t\t\t\tDay of departure:" + dayofdeparture[logincount]);
                Console.WriteLine("\t\t\t\t\t\tID No:" + ID[logincount]);
                Console.WriteLine("\t\t\t\t\t\tTicket Price: $" + price);
                Console.WriteLine("\t\t\t\t\t\tFligth status:" + resultOfBudget);
                Console.WriteLine("\t\t\t\t\t\tSelected Class:" + clas[logincount]);
                Console.WriteLine("\t\t\t\t\t\tDiscount status:" + discountavailability);
                Console.WriteLine("\t\t\t\t\t\tYour selected airline: " + airline[logincount]);
                Console.WriteLine("\t\t\t\t\t\tReviews: " + reviews[logincount]);

            }
        }

        static bool checkSignInAgain(string name, ref int customercount, string[] Name, string[] country, string[] gender, string[] age, string[] departure, string[] arrival, string[] legspace, string[] extrafood, string[] Date, string[] dayofdeparture, string[] ID, string[] clas, string[] airline, string[] Reviews)
        {
            string var;
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            StreamReader file=new StreamReader(path);
            
            int x = 0;
            while ((var=file.ReadLine())!=null)
            {
                
                if (getField(var, 1) == name && int.Parse(getField(var, 17)) == 1)
                {
                    customercount = int.Parse(getField(var, 18));
                    Name[customercount] = getField(var, 2);
                    country[customercount] = getField(var, 3);
                    gender[customercount] = getField(var, 4);
                    age[customercount] = getField(var, 5);
                    departure[customercount] = getField(var, 6);
                    arrival[customercount] = getField(var, 7);
                    legspace[customercount] = getField(var, 8);
                    extrafood[customercount] = getField(var, 9);
                    Date[customercount] = getField(var, 10);
                    dayofdeparture[customercount] = getField(var, 11);
                    ID[customercount] = getField(var, 12);
                    clas[customercount] = getField(var, 14);
                    airline[customercount] = getField(var, 15);
                    Reviews[customercount] = getField(var, 16);

                    return true;
                    break;
                }
            }
            file.Close();
            return false;
        }

        static void storeUserData(string name, string[] Name, string[] country, string[] gender, string[] age, string[] departure, string[] arrival, string[] legspace, string[] extrafood, string[] Date, string[] dayofdeparture, string[] ID, float price, string[] clas, string[] airline, string[] reviews, int logincount, int[] signIncount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TicketsData.txt";
            StreamWriter file=new StreamWriter(path,true);
            
            file .WriteLine(name + "," + Name[logincount] + "," + country[logincount] + "," + gender[logincount] + "," + age[logincount] + "," + departure[logincount] + "," + arrival[logincount] + "," + legspace[logincount] + "," + extrafood[logincount] + "," + Date[logincount] + "," + dayofdeparture[logincount] + "," + ID[logincount] + "," + price + "," + clas[logincount] + "," + airline[logincount] + "," + reviews[logincount] + "," + signIncount[logincount] + "," + logincount + "," );
            file.Close();
        }
        static void outputAgain(string[] Name, string[] country, string[] gender, string[] age, string[] departure, string[] arrival, string[] legspace, string[] extrafood, string[] Date, string[] dayofdeparture, string[] ID, string[] clas, string[] airline, string[] reviews, int logincount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            string resultOfBudget = "Fligth status is OK. ";
            StreamReader file=new StreamReader(path);
            
            string var;
            while ((var = file.ReadLine())!=null)
            {
                 var=file.ReadLine();
            }
            if (Name[logincount] == "")
            {
                resultOfBudget = "your ticket has been cancelled";
            }

            Console.WriteLine("\t\t\t\t\t\t" + Name[logincount]);
            Console.WriteLine("\t\t\t\t\t\t" + country[logincount]);
            Console.WriteLine("\t\t\t\t\t\t" + gender[logincount]);
            Console.WriteLine("\t\t\t\t\t\t" + age[logincount]);
            Console.WriteLine("\t\t\t\t\t\tDeparture: " + departure[logincount]);
            Console.WriteLine("\t\t\t\t\t\tArrival: " + arrival[logincount]);
            Console.WriteLine("\t\t\t\t\t\tServices:");
            Console.WriteLine("\t\t\t\t\t\tLeg Space: " + legspace[logincount]);
            Console.WriteLine("\t\t\t\t\t\tFood Service: " + extrafood[logincount]);
            Console.WriteLine("\t\t\t\t\t\tDate of Departure: " + Date[logincount]);
            Console.WriteLine("\t\t\t\t\t\tDay of departure:" + dayofdeparture[logincount]);
            Console.WriteLine("\t\t\t\t\t\tID No:" + ID[logincount]);
            Console.WriteLine("\t\t\t\t\t\tFligth status:" + resultOfBudget);
            Console.WriteLine("\t\t\t\t\t\tSelected Class:" + clas[logincount]);
            Console.WriteLine("\t\t\t\t\t\tYour selected airline: " + airline[logincount]);
            Console.WriteLine("\t\t\t\t\t\tReviews: " + reviews[logincount]);

        }

        static int cal1(string[] leg, string[] food, int logincount, int totalprice, int ticketprice, string[] clas, int business, int legspace, int foodservice)
        { // function for calculating the price after extra cgarges

            int price1 = 0;
            if ((leg[logincount] == "Yes" || leg[logincount] == "yes") && (food[logincount] == "No" || food[logincount] == "no") && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + legspace + business;
            }

            else if ((leg[logincount] == "Yes" || leg[logincount] == "yes") && (food[logincount] == "Yes" || food[logincount] == "yes") && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + legspace + foodservice + business;
            }

            else if ((leg[logincount] == "No" || leg[logincount] == "no") && (food[logincount] == "Yes" || food[logincount] == "yes") && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + foodservice + business;
            }

            else if ((leg[logincount] == "No" || leg[logincount] == "no") && (food[logincount] == "No" || food[logincount] == "no") && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + business;
            }
            else if ((leg[logincount] == "Yes" || leg[logincount] == "yes") && (food[logincount] == "Yes" || food[logincount] == "yes") && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice + foodservice + legspace;
            }
            else if ((leg[logincount] == "No" || leg[logincount] == "no") && (food[logincount] == "Yes" || food[logincount] == "yes") && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice + foodservice;
            }
            else if ((leg[logincount] == "Yes" || leg[logincount] == "yes") && (food[logincount] == "No" || food[logincount] == "no") && (clas[logincount] == "Ecocnomy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice + legspace;
            }
            else if ((leg[logincount] == "No" || leg[logincount] == "no") && (food[logincount] == "No" || food[logincount] == "no") && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice;
            }
            else if (leg[logincount] == "yes" || leg[logincount] == "Yes" && (food[logincount] == "Yes" || food[logincount] == "yes"))
            {
                price1 = ticketprice + legspace + foodservice;
            }
            else if (leg[logincount] == "no" || leg[logincount] == "No" && (food[logincount] == "No" || food[logincount] == "no"))
            {
                price1 = ticketprice;
            }
            else if (food[logincount] == "Yes" || food[logincount] == "yes" && (leg[logincount] == "No" || leg[logincount] == "no"))
            {
                price1 = ticketprice + foodservice;
            }
            else if (food[logincount] == "No" || food[logincount] == "no" && (leg[logincount] == "Yes" || leg[logincount] == "yes"))
            {
                price1 = ticketprice + legspace;
            }
            else if (clas[logincount] == "Business" || clas[logincount] == "business")
            {
                price1 = ticketprice + business;
            }
            else if (clas[logincount] == "Economy" || clas[logincount] == "economy")
            {
                price1 = ticketprice;
            }
            else if (leg[logincount] == "Yes" || leg[logincount] == "yes" && (food[logincount] == "Yes" || food[logincount] == "yes"))
            {
                price1 = ticketprice + legspace + foodservice;
            }
            else if (leg[logincount] == "no" || leg[logincount] == "No" && (food[logincount] == "yes" || food[logincount] == "Yes"))
            {
                price1 = ticketprice + foodservice;
            }
            else if (leg[logincount] == "Yes" || leg[logincount] == "yes" && (food[logincount] == "No" || food[logincount] == "no"))
            {
                price1 = ticketprice + legspace;
            }
            else if (leg[logincount] == "No" || leg[logincount] == "no" && (food[logincount] == "No" || food[logincount] == "no"))
            {
                price1 = ticketprice;
            }
            else if (food[logincount] == "Yes" || food[logincount] == "yes" && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + foodservice + business;
            }
            else if (food[logincount] == "No" || food[logincount] == "no" && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + business;
            }
            else if (food[logincount] == "No" || food[logincount] == "no" && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice;
            }
            else if (food[logincount] == "Yes" || food[logincount] == "yes" && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice;
            }
            else if (leg[logincount] == "Yes" || leg[logincount] == "yes" && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice + legspace;
            }
            else if (leg[logincount] == "No" || leg[logincount] == "no" && (clas[logincount] == "Economy" || clas[logincount] == "economy"))
            {
                price1 = ticketprice;
            }
            else if (leg[logincount] == "No" || leg[logincount] == "no" && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + business;
            }
            else if (leg[logincount] == "Yes" || leg[logincount] == "yes" && (clas[logincount] == "Business" || clas[logincount] == "business"))
            {
                price1 = ticketprice + business + legspace;
            }
            else if (leg[logincount] == "" && food[logincount] == "" && (clas[logincount] == ""))
            {
                price1 = ticketprice;
            }

            logincount++;
            return price1;
        }
        static void checkUser(string name, string[] username, ref int logincount)
        {
            username[logincount] = name;
            logincount++;
        }
        static float discountedvalue(ref float totalprice, float percentage)
        { // function to calculte rhe discounted value
            float finalprice;
            finalprice = totalprice - totalprice * (percentage / 100);
            return finalprice;
        }

        static void personalInformation(string[] name, string[] country, string[] ID, string[] gender, string[] age, int logincount)
        { // function to take input from user
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            while (true)
            {

                Console.WriteLine("Enter your name: ");

                name[logincount] = Console.ReadLine();
                if (checkeEmpty(name[logincount]) == true || checkstring(name[logincount]) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the country you live in: ");

                 country[logincount]=Console.ReadLine();
                if (checkeEmpty(country[logincount]) == true || checkstring(country[logincount]) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }

            while (true)
            {

                Console.WriteLine("Enter your ID Number: ");
                string IDnum;

                 IDnum=Console.ReadLine();

                if (check_number(IDnum, 13) == true || check_int(IDnum) == true || checkeEmpty(IDnum) == true || checkCNIC(ID, IDnum, logincount) == true)
                {

                    Console.WriteLine("Invalid input or this CNIC is already present.");

                }
                else
                {
                    ID[logincount] = IDnum;
                    break;
                }
            }

            while (true)
            {

                Console.WriteLine("Enter your gender:");

                 gender[logincount]=Console.ReadLine();
                if (checkeEmpty(gender[logincount]) == true || (gender[logincount] != "male" && gender[logincount] != "female" && gender[logincount] != "Male" && gender[logincount] != "Female") || checkSpace(gender[logincount])==true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter your age:");

                 age[logincount]=Console.ReadLine();
                if (checkeEmpty(age[logincount]) == true || check_int(age[logincount]) == true || checkSpace(age[logincount])==true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }
        }
        static bool checkRoles(string roles)
        {
            if (roles != "user" && roles != "User" && roles != "Customer" && roles != "customer" && roles != "Admin" && roles != "admin" && roles != "owner" && roles != "Owner" && roles != "Manager" && roles != "manager")
            {
                return true;
            }
            else
                return false;
        }
        static void readDiscountPercentage(ref float discountpercentage)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\PercentageData.txt";
            StreamReader file=new StreamReader(path);
            
           discountpercentage =float.Parse(file.ReadLine());
            file.Close();
        }
        static int totalprice(int total)
        { // returns the total price
            return total;
        }
        static bool checkArrival(string[] availableArrival, string arrival, int logincount, string[] departure, int logincount1)
        {
            for (int x = 0; x < logincount; x++)
            {
                if (arrival == availableArrival[x])
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkDeparture(string[] availableDeparture, string departure, int logincount, string[] arrival, int logincount1)
        {
            for (int x = 0; x < logincount; x++)
            {
                if (departure == availableDeparture[x])
                {
                    return false;
                }
            }
            return true;
        }

        static void flightInformation(string[] arrival, string[] departure, string[] date, string[] dayOfDeparture, int logincount, string[] availableDepartue, string[] availableArrivals, int departurecount, int arrivalcount)
        { // takes input about flight
            viewShedule(availableArrivals, availableDepartue, ref departurecount, ref arrivalcount);
            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            while (true)
            {

                Console.WriteLine("Enter the place of departure: ");

                departure[logincount] = Console.ReadLine();
                if (checkeEmpty(departure[logincount]) == true || checkstring(departure[logincount]) == true || checkDeparture(availableDepartue, departure[logincount], departurecount, availableArrivals, arrivalcount) == true)
                {

                    Console.WriteLine("Invalid input or this place is not present in the record.");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the place of arrival: ");

                arrival[logincount] = Console.ReadLine();
                if (checkeEmpty(arrival[logincount]) == true || checkstring(arrival[logincount]) == true || checkPlaces(arrival, departure, logincount) == true || checkArrival(availableArrivals, arrival[logincount], arrivalcount, availableDepartue, departurecount) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }

                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the date of departure: ");


                date[logincount] = Console.ReadLine();
                if (checkeEmpty(date[logincount]) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the day of departure(the first letter must be capital): ");

                dayOfDeparture[logincount] = Console.ReadLine();
                if (checkeEmpty(dayOfDeparture[logincount]) == true || checkstring(dayOfDeparture[logincount]) == true || checkDays(dayOfDeparture[logincount]) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }
        }

        static void InflightServices(string[] leg, string[] food, int logincount)
        { // takes input about inflight services
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            Console.WriteLine("Which services you want to avail: ");

            while (true)
            {

                Console.WriteLine("Extra leg space(Yes/No): ");

                leg[logincount] = Console.ReadLine();
                if (checkeEmpty(leg[logincount]) == true || checkstring(leg[logincount]) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Food Service(Yes/No):");

                food[logincount] = Console.ReadLine();
                if (checkeEmpty(food[logincount]) == true || checkstring(food[logincount]) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
        }
        static string subMenuBeforeMainMenu(string message)
        { // returns the submenu
            string menu = message + "Menu";
            return menu;

            Console.WriteLine("*.......................*");

        }
        static void printscreen()
        {
            Console.Clear();
            printHeader();
        }

        static string classSelection(string[] clas, int logincount)
        { // returns the class selected by the user
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            Console.WriteLine("Select your class: ");
            Console.WriteLine(" Economy");
            Console.WriteLine(" Business");

            while (true)
            {

                Console.WriteLine(" Write your class here: ");

                clas[logincount] = Console.ReadLine();
                if (checkeEmpty(clas[logincount]) == true || checkstring(clas[logincount]) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }

            return clas[logincount];
        }

        static string reviews(string[] review, int logincount)
        { // returns the reviews entered by user
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            while (true)
            {

                Console.WriteLine("Enter your reviews: ");

                review[logincount] = Console.ReadLine();
                if (checkeEmpty(review[logincount]) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }

            return review[logincount];
        }
        static bool budget(int budget, int ticketprice)
        { // checks if the enetred budget is enough or not.
            bool statement;

            if (budget >= ticketprice)
            {
                statement = false;
            }
            else
            {
                statement = true;
            }
            return statement;
        }
        static void availableAirline(string[] airline, ref int count)
        { // printsavailable airlines enterd by the owner
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Airlinedata.txt";
            StreamReader file = new StreamReader(path);
            
            string var;
            int x = 0;
            if(File.Exists(path))
            {
                while ((var=file.ReadLine())!=null)
                {
                    
                    airline[x] = getField(var, 1);

                    x++;
                    count++;
                }
            }
            file.Close();
          
            for (int index = 0; index < x - 1; index++)
            {

                Console.WriteLine("\t\t\t\t\t\t" + index + 1 + ". " + airline[index]);

            }
        }

        static void selectairline(string[] airlines, int airlineChoice, int aircount, string[] selectedairlines, int logincount)
        { // returns the selected airline
            string result;

            if (airlineChoice - 1 > aircount)
            {

                result = "Invalid option.";

            }
            else
            {
                selectedairlines[logincount] = airlines[airlineChoice - 1];
            }
        }
        static void viewDiscountOptions(string[] discount, int dayscount)
        { // prints the days on which discount is available
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Discountdata.txt";
            StreamReader file=new StreamReader(path);
            
            string var;
            int index = 0;
            if(File.Exists(path))
            {
                while ((var=file.ReadLine())!=null)
                {
                     var=file.ReadLine();
                    discount[index] = getField(var, index + 1);
                    index++;
                }
            }
            
            file.Close();
            for (int x = 0; x < index; x++)
            {

                Console.Write(x + 1 + ". " + discount[x]);

            }
        }
        static string discountday(string[] Discountday, int dayscount, int option)
        { // returns the option selected by user
           option=int .Parse(Console.ReadLine());
            return Discountday[option - 1];
        }
        static bool isDiscountAvailable(string[] day, int logincount, int daysofdiscount, string[] discount)
        { // checks whether discount is avaible or not
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Discountdata.txt";
            StreamReader file=new StreamReader(path);
            string variable;
        
            int x = 0;
            if(File.Exists(path))
            {
                while ((variable=file.ReadLine())!=null)
                {
                    
                    discount[x] = getField(variable, x + 1);
                    x++;
                }
            }
            file.Close();

            bool isFound = false;
            for (int index = 0; index < x; index++)
            {
                if (day[logincount] == discount[index])
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        static string OwnerInterface(string op)
        { // prints the owner interface

            Console.WriteLine("\t\t\t\t\tSelect one of the folowing option: ");
            Console.WriteLine("\t\t\t\t\t1. Add employee: ");
            Console.WriteLine("\t\t\t\t\t2. Remove employee: ");
            Console.WriteLine("\t\t\t\t\t3. Add Airline:  ");
            Console.WriteLine("\t\t\t\t\t4. View employee list:");
            Console.WriteLine("\t\t\t\t\t5. Price allocation:");
            Console.WriteLine("\t\t\t\t\t6. Price allocation for services:");
            Console.WriteLine("\t\t\t\t\t7. Salary allocation to employees:  ");
            Console.WriteLine("\t\t\t\t\t8. Discount allocation:");
            Console.WriteLine("\t\t\t\t\t9. Enter the percentage of discount:  ");
            Console.WriteLine("\t\t\t\t\t10. Announce something to the employee: ");
            Console.WriteLine("\t\t\t\t\t11. Customer reviews:");
            Console.WriteLine("\t\t\t\t\t12. Revenue interface: ");
            Console.WriteLine("\t\t\t\t\t13. Log out");
            Console.WriteLine("\t\t\t\t\tEnter your choice : ");

            op = Console.ReadLine();
            return op;
        }
        static void addEmployeeData(string name, string ID, string[] usernameForEmployee, int logincount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\EmployeeData.txt";
            StreamWriter file = new StreamWriter(path,true);
           
            
            file .Write( name + ",");
            file .Write( ID + ",");
            file .WriteLine( usernameForEmployee[logincount] + ",");
            

            file.Close();
        }
        static bool Addemployee(string name, string ID, string[] employee, string[] IDNUM, ref int logincount, string username, string[] usernameforemployee)
        { // add the employee
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\EmployeeData.txt";
            StreamReader file = new StreamReader(path);
            
            string var;
            int index = 0;
            while ((var = file.ReadLine())!=null)
            {
                
                employee[index] = getField(var, 1);
                IDNUM[index] = getField(var, 2);
                usernameforemployee[index] = getField(var, 3);

                index++;
            }
            file.Close();
            bool isFound = true;
            for (int x = 0; x < index - 1; x++)
            {
                if (username == usernameforemployee[x] || ID == IDNUM[x])
                {
                    isFound = false;
                    break;
                }
            }
            if (isFound == true)
            {
                employee[logincount] = name;
                IDNUM[logincount] = ID;
                usernameforemployee[logincount] = username;
                addEmployeeData(name, ID, usernameforemployee, logincount);
                logincount++;
            }

            return isFound;
        }
        static bool removeEmployeeData(string removingEmployee, string[] employees, string[] ID, string[] username, ref int logincount)
        {
            string result;
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\EmployeeData.txt";
            StreamReader file = new StreamReader(path);
           
            string var;
            int x = 0;
            if(File.Exists(path))
            {
                while ((var = file.ReadLine())!=null)
                {
                    
                    result = getField(var, 3);
                    if (result == removingEmployee)
                    {
                        employees[x] = "";
                        ID[x] = "";
                        username[x] = "";
                        addEmployeeDataAfterRemoval(employees, ID, username, ref logincount);
                        return true;
                    }

                    x++;
                }
            }
           
            file.Close();
            return false;
        }
        static void addEmployeeDataAfterRemoval(string[] employee, string[] ID, string[] username, ref int logincount)
        {
            int z = -1;
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\EmployeeData.txt";
            StreamWriter file = new StreamWriter(path, false);

            for (int x = 0; x < logincount; x++)
            {
                if (employee[x] == "")
                {
                    z = x;
                    continue;
                }
                file.WriteLine(employee[x] + "," + ID[x] + "," + username[x] + ",");
                if (z != -1)
                {
                    logincount--;
                }
            }

        }


        static bool removeEmployee(string removingEmployee, string[] name, string[] ID, ref int logincount, string[] usernameForEmployee)
        { // removes the employee
            bool isfound = false;
            if (removeEmployeeData(removingEmployee, name, ID, usernameForEmployee, ref logincount) == true)
            {
                isfound = true;
            }

            return isfound;
        }
        static void AirlineData(string airline, string airlineCode)

        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\AirlineData.txt";
            StreamWriter file = new StreamWriter(path,true);
           
            file .Write( airline + ",");
            file .WriteLine( airlineCode + "," );
            file.Close();
        }
        static int revenueInterface(int totalprice)
        {
            // returns the total revenue
            readTotalrevenue(ref totalprice);
            return totalprice;
        }
        static void addAirline(string[] airline, string[] airlinecode, ref int aircount)
        {
            // adds the airline enetred by owner
            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string var;
            bool isFound = true;
            string var1;
            while (true)
            {

                Console.WriteLine("Enter the Airline: ");

                 var1=Console.ReadLine();
                if (checkeEmpty(var1) == true)
                {

                    Console.WriteLine("invalid input.");

                }
                else
                {
                    break;
                }
            }

            while (true)
            {

                Console.WriteLine("Enter the Airline Code(must be 3 integers): ");

                 var=Console.ReadLine();
                if (check_int(var) == true || check_number(var, 3) == true || checkeEmpty(var) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\AirlineData.txt";
            StreamReader file=new StreamReader(path);
            
            string variable;
            int x = 0;
            if(File.Exists(path))
            {
                while ((variable = file.ReadLine())!= null)
                {
                    
                    airlinecode[x] = getField(variable, 2);
                    airline[x] = getField(variable, 1);
                    x++;
                    aircount++;
                }
            }
            
            file.Close();
            for (int index = 0; index < x - 1; index++)
            {
                if (var == airlinecode[index] || airline[index] == var1)
                {

                    Console.WriteLine("Airline alredy present.");

                    isFound = false;
                    break;
                }
            }
            if (isFound == true)
            {
                AirlineData(var1, var);

                airline[aircount] = var1;
                airlinecode[aircount] = var;
                aircount++;
            }
        }
        static void readReviews(string[] reviews, ref int var)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            StreamReader file=new StreamReader(path);
            
            string line;
            while ((line=file.ReadLine())!=null)
            {
                
                reviews[var] = getField(line, 16);
                var++;
            }
            file.Close();
        }
        static void customerReviews(string[] customerreviews, int logincount)
        {
            // prints the customer reviews
            int var = 0;
            readReviews(customerreviews, ref var);



            if (logincount == 0)
            {
                Console.WriteLine("There are no customer reviews yet.");
            }
            else
            {
                for (int index = 0; index < var - 1; index++)
                {
                    if (customerreviews[index] == "")
                    {
                        Console.WriteLine("This customer has not shared any reviews or the ticket has been cancelled.");
                    }
                    else
                    {
                        Console.Write(customerreviews[index]);

                    }
                }
            }
        }
        static void employeeList(string[] employee, string[] IDnum, string[] username, ref int logincount)
        {
            // prints the employee list
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\EmployeeData.txt";
            StreamReader file =new StreamReader(path);
         
            string var;

            Console.WriteLine("\t\t\t\t\t\t\tName"
                 + "\t\t "
                 + "ID"
                 + "\t\tUsername");

            int index = 0;
            if(File.Exists(path))
            {
                while ((var=file.ReadLine())!=null)
                {
                    

                    employee[index] = getField(var, 1);
                    IDnum[index] = getField(var, 2);
                    username[index] = getField(var, 3);
                    index++;
                }
            }
           
            file.Close();
            for (int x = 0; x < index - 1; x++)
            {
                Console.WriteLine("\t\t\t\t\t\t\t" + employee[x] + "\t\t " + IDnum[x] + "\t\t" + username[x]);

            }
        }
        static void addPrice(int ticketprice)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\addPrice.txt";
            StreamWriter file = new StreamWriter(path,false);
           
            file .WriteLine( ticketprice);
            file.Close();
        }
        static int pricealloaction(ref int ticketprice)
        { // allocates the price to the user
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string var1;

            while (true)
            {
                Console.WriteLine("Enter the price of ticket: ");


                 var1=Console.ReadLine();
                if (check_int(var1) == true || checkeEmpty(var1) == true)
                {
                    Console.WriteLine("Invalid input.");
                }
                else
                {
                    break;
                }
            }

            ticketprice = int.Parse(var1);
            addPrice(ticketprice);
            return ticketprice;
        }
        static void addExtraCharges(int business, int legspace, int food)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\ExtraCharges.txt";
            StreamWriter file=new StreamWriter(path,false);
           
            file .WriteLine( legspace + "," + food + "," + business );
        }
        static void extraCharges(ref int business, ref int legspace, ref int food)
        { // takes input from owner about extra charges
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string leg, foodservice, clas;
            while (true)
            {

                Console.WriteLine("Enter the charges for legspace:");

                leg = Console.ReadLine();
                if (check_int(leg) == true || checkeEmpty(leg) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the charges for food service: ");

                foodservice = Console.ReadLine();
                if (check_int(foodservice) == true || checkeEmpty(foodservice) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }
            while (true)
            {

                Console.WriteLine("Enter the charges for business class: ");

                clas = Console.ReadLine();
                if (check_int(clas) == true || checkeEmpty(clas) == true)
                {

                    Console.WriteLine("Invalid input.");

                }
                else
                {
                    break;
                }
            }
            legspace = int.Parse(leg);
            food = int.Parse(foodservice);
            business = int.Parse(clas);
            addExtraCharges(business, legspace, food);
        }
        static int salaryfixation(ref int salary)
        { // takes input from owner about salary
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string checkSalary;

            while (true)
            {
                Console.WriteLine("How much salary do you want to pay: ");

                checkSalary = Console.ReadLine();
                if (check_int(checkSalary) == true || checkeEmpty(checkSalary) == true)
                {

                    Console.WriteLine("Invalid input.");
                }
                else
                {
                    break;
                }
            }
            salary = int.Parse(checkSalary);

            return salary;
        }
        static void readTotalrevenue(ref int totalrevenue)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TotalRevenueData.txt";
            StreamReader file = new StreamReader(path);

            totalrevenue = int.Parse(file.ReadLine());
            file.Close();
        }
        static int salarymanagement(string[] employee, int count, ref int totalrevenue, string[] IDnum, int salary)
        { // allocates the salary to employee

            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Employeedata.txt";
            StreamReader file = new StreamReader(path);

            string var;
            int index = 0;
            if (File.Exists(path))
            {
                while ((var = file.ReadLine()) != null)
                {

                    employee[index] = getField(var, 1);
                    IDnum[index] = getField(var, 2);
                    index++;
                }
            }

            readTotalrevenue(ref totalrevenue);
            string answer;

            for (int x = 0; x < index - 1; x++)
            {
                if ((employee[x] != "" && IDnum[x] != ""))
                {

                    Console.WriteLine(employee[x] + "\t"
                         + "Yes/No:");

                    answer = Console.ReadLine();

                    if (answer == "Yes" || answer == "yes")
                    {
                        totalrevenue = totalrevenue - salary;
                        totalrevenueData(totalrevenue);
                    }
                }

                else
                {
                    totalrevenue = totalrevenue;
                    totalrevenueData(totalrevenue);
                }
            }

            return totalrevenue;
        }
        static void clearscreen()
        {

            Console.WriteLine("Press any key to continue: ");

            Console.Read();
        }
        static void discountData(string[] discount, int discountcount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\DiscountData.txt";
            StreamWriter file = new StreamWriter(path,false);
            
            if (discountcount == 0)
            {
                file .Write( "");
            }
            else
            {
                for (int x = 0; x < discountcount; x++)
                {
                    file .Write( discount[x] + ",");
                }
            }

            file.Close();
        }
        static void discount(string[] discount, ref int dayscount)
        { // takes input from owner about discount option.
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            Console.WriteLine("Enter on how many days you want to give discount: ");

            dayscount = int.Parse(Console.ReadLine());
            for (int index = 0; index < dayscount; index++)
            {
                while (true)
                {


                    Console.WriteLine("Enter the day on which you want to give discount: ");


                    discount[index] = Console.ReadLine();
                    if (checkstring(discount[index]) == true || checkeEmpty(discount[index]) == true)
                    {

                        Console.WriteLine("Invalid input.");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            discountData(discount, dayscount);
        }
        static void announcementData(string announcement)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\AnnouncementData.txt";
            StreamWriter file=new StreamWriter(path,false);
            
            file .WriteLine( announcement);
            file.Close();
        }

        static void announcementToEmployee(ref string announcement)
        { // takes input from owner about announcements
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            while (true)
            {
                Console.WriteLine("What you want to announce to employee:");

                announcement = Console.ReadLine();
                if (checkeEmpty(announcement) == true)
                {

                    Console.WriteLine("Invalid input.");
                }
                else

                {
                    break;
                }
            }
            announcementData(announcement);
        }
        static void percentageData(float percentage)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\PercentageData.txt";
            StreamWriter file = new StreamWriter(path,false);
            file.WriteLine(percentage);

            file.Close();
        }
        static float percentageOfDiscount(ref float percentage)
        { // takes input regarding to percenrage of discount
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string result;
            result = Console.ReadLine();
            percentage = float.Parse(result);

            percentageData(percentage);
            return percentage;
        }
        static string Employeeinterface(string op)
        { // prints the employee interface

            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            Console.WriteLine("\t\t\t\t\t\tSelect one of the following option:");
            Console.WriteLine("\t\t\t\t\t\t1. Enter the shedule of tckets: ");
            Console.WriteLine("\t\t\t\t\t\t2. View how many tickets have been sold.");
            Console.WriteLine("\t\t\t\t\t\t3. View which airlines have been selected.");
            Console.WriteLine("\t\t\t\t\t\t4. View which services have been selected.");
            Console.WriteLine("\t\t\t\t\t\t5. Profit and loss calculation:");
            Console.WriteLine("\t\t\t\t\t\t6. View announcements from owner: ");
            Console.WriteLine("\t\t\t\t\t\t7. View information of customer:");

            Console.WriteLine("\t\t\t\t\t8. Log out.");

            op = Console.ReadLine();
            return op;
        }
        static void Loading()
        {
            Console.WriteLine(" _                    _ _     ");
            Console.WriteLine("| |    ___   __ _  __| (_)_ __   __ _  ");
            Console.WriteLine("| |   / _ \\ / _` |/ _` | | '_ \\ / _` | ");
            Console.WriteLine("| |__| (_) | (_| | (_| | | | | | (_| |  ");
            Console.WriteLine("|_____\\___/ \\__,_|\\__,_|_|_| |_|\\__, |   ");
            Console.WriteLine("                                |___/    ");
            Console.WriteLine(".");
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine(".");

            }
        }
        static void loginmenu()
        {

            Console.WriteLine("\t\t\t\t\t\t\t _                _         __  __      ");
            Console.WriteLine("\t\t\t\t\t\t\t| |    ___   __ _(_)_ __   |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t| |   / _ \\ / _` | | '_ \\  | |\\/| |/ _ \\ '_ \\| | | |  ");
            Console.WriteLine("\t\t\t\t\t\t\t| |__| (_) | (_| | | | | | | |  | |  __/ | | | |_| |   ");
            Console.WriteLine("\t\t\t\t\t\t\t|_____\\___/ \\__, |_|_| |_| |_|  |_|\\___|_| |_|\\__,_|  ");
            Console.WriteLine("\t\t\t\t\t\t\t            |___/                                     ");
        }
        static void addTickestCount(int logincount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TicketsData.txt";
            StreamWriter file=new StreamWriter(path,false);
            
            file .WriteLine( logincount );
            file.Close();
        }
        static int ticketscount(int logincount)
        { // counts how many tickets have been sold
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TicketsData.txt";
            StreamReader file = new StreamReader(path);
            
             logincount=int.Parse(file.ReadLine());
            return logincount;
        }

        static void viewselectedAirlines(string[] selectedairline, int logincount)
        { // prints the seleted airlines
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            StreamReader file= new StreamReader(path);
            string var;
         
            int x = 0;
            if(File.Exists(path))
            {
                while ((var = file.ReadLine())!=null)
                {
                    

                    selectedairline[x] = getField(var, 15);
                    x++;
                }
            }
            
            file.Close();
            for (int index = 0; index < x - 1; index++)
            {


                if (selectedairline[index] == "")
                {

                    Console.WriteLine("The ticket has been cancelled.");
                }
                else
                {
                    Console.Write(index + 1 + ". " + selectedairline[index]);

                }
            }
        }
        static void viewselectedServices(string[] leg, string[] food, string[] clas, int logincount)
        { // prints the selected services
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            StreamReader file = new StreamReader(path);
            
            string var;
            int x = 0;
            if(File.Exists(path))
            {
                while ((var = file.ReadLine())!=null)
                {
                    
                    leg[x] = getField(var, 8);
                    food[x] = getField(var, 9);
                    x++;
                }
            }
           
            file.Close();


            Console.WriteLine("LegService  Foodservice   ");

            for (int index = 0; index < x - 1; index++)
            {

                Console.Write(leg[index] + "     " + food[index]);

                if (leg[index] == "" && food[index] == "")
                {
                    Console.WriteLine("Cancelled  Cancelled");
                }
                else if (leg[index] == "")
                {
                    Console.WriteLine("Cancelled");
                }
                else if (food[index] == "")
                {
                    Console.WriteLine("Cancelled");
                }
            }
        }
        static void totalrevenueData(int totalrevenue)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\TotalRevenueData.txt";
            
                StreamWriter file = new StreamWriter(path, false);

                file.WriteLine(totalrevenue);


            file.Flush();
            file.Close();

        }
        static void profitandLoss(ref int totalrevenue)
        { // calcultes whether there is profit or loss
          ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string fuel;

            while (true)
            {
                Console.WriteLine("Enter the expenses of fuel: ");

                fuel = Console.ReadLine();
                if (check_int(fuel) == true || checkeEmpty(fuel) == true)
                {

                    Console.WriteLine("Invalid input.");
                }
                else
                {
                    break;
                }
            }
            string electricity;
            while (true)
            {

                Console.WriteLine("Enter the expenses of electricity: ");


                electricity = Console.ReadLine();
                if (checkeEmpty(electricity) == true || check_int(electricity) == true)
                {

                    Console.WriteLine("Invalid input. ");

                }
                else
                {
                    break;
                }
            }

            readTotalrevenue(ref totalrevenue);
            int totalexpenses = int.Parse(fuel) + int.Parse(electricity);
            if (totalexpenses > totalrevenue)
            {
                int result;
                result = totalexpenses - totalrevenue;


                Console.WriteLine("There has been loss of $" + result);

                for (int x = 0; x < 10; x++)
                {

                    Console.WriteLine("|");
                    if (x + 1 == 10)
                    {
                        Console.WriteLine("________LOSS_________");
                    }
                }
            }
            else if (totalrevenue > totalexpenses)
            {
                int result;
                result = totalrevenue - totalexpenses;


                Console.WriteLine("There has been profit of $" + result);

                for (int x = 0; x < 10; x++)
                {

                    Console.WriteLine("|");
                    if (x + 1 == 10)
                    {
                        Console.WriteLine("_________Profit______________");
                    }
                }
            }
        }
        static void viewAnnouncements(string announcement)
        { // view the announvemets from owner
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\AnnouncementData.txt";
            StreamReader file =new StreamReader(path);
            if(File.Exists(path))
            {
                 announcement=file.ReadLine();
                file.Close();
            }
            
            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            Console.WriteLine(announcement);

        }
        static void viewCustomerInformation(string[] name, string[] ID, string[] country, string[] gender, string[] age, string[] arrival, string[] departure, string[] date, string[] day, int logincount)
        {
            ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            Console.WriteLine("Enter the name of customer whose Information you want to see:");

            string nameofUser;
            nameofUser = Console.ReadLine();


            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
            StreamReader file = new StreamReader(path);
            string var;
            if (File.Exists(path))
            {
                while ((var = file.ReadLine()) != null)
                {

                    if (nameofUser == getField(var, 2))
                    {
                        logincount = int.Parse(getField(var, 18));
                        name[logincount] = getField(var, 2);
                        ID[logincount] = getField(var, 12);
                        country[logincount] = getField(var, 3);
                        gender[logincount] = getField(var, 4);
                        age[logincount] = getField(var, 5);
                        arrival[logincount] = getField(var, 6);
                        departure[logincount] = getField(var, 7);
                        date[logincount] = getField(var, 10);
                        day[logincount] = getField(var, 11);
                        break;
                    }
                }
            }

            if (name[logincount] == "")
            {

                Console.WriteLine("No such customer is present or the ticket has been cancelled.");
            }
            else
            {

                Console.WriteLine(name[logincount]);
                Console.WriteLine(ID[logincount]);
                Console.WriteLine(country[logincount]);
                Console.WriteLine(gender[logincount]);
                Console.WriteLine(age[logincount]);
                Console.WriteLine(arrival[logincount]);
                Console.WriteLine(departure[logincount]);
                Console.WriteLine(date[logincount]);
                Console.WriteLine();

            }

        }

        static void cancelllationOfTicket(string[] name, string[] ID, string[] gender, ref int totalrevenue, string[] age, string[] departure, string[] arrival, string[] leg, string[] food, string[] clas, string[] date, string[] day, ref float price, string[] reviews, int logincount, string[] airline)
        { // cancells the ticket of user
            totalrevenue = (int)(totalrevenue - price);
            name[logincount] = " ";
            ID[logincount] = " ";
            gender[logincount] = " ";
            age[logincount] = " ";
            departure[logincount] = " ";
            arrival[logincount] = " ";
            leg[logincount] = " ";
            food[logincount] = " ";
            clas[logincount] = " ";
            date[logincount] = " ";
            day[logincount] = " ";
            price = 0;
            reviews[logincount] = " ";
            airline[logincount] = " ";
        }

        static bool check_number(string check, int length)
        { // function to check the length of input.

            if (check.Count() != length)
            {
                return true;
            }
            return false;
        }
        static bool check_int(string var)
        { // function to check whether the input is  integer

            for (int x = 0; var[x] != '\0'; x++)
            {

                
                if (var[x] != 48 && var[x] != 49 && var[x] != 50 && var[x]!= 51 && var[x] != 52 && var[x] != 53 && var[x] != 54 && var[x] != 55 && var[x] != 56 && var[x]!= 57)
                {

                    return true;
                }
            }
            return false;
        }
        static bool checkDays(string check)
        {
            if (check == "Sunday" || check == "Monday" || check == "Tuesday" || check == "Wednesday" || check == "Thursday" || check == "Friday" || check == "Saturday")
            {
                return false;
            }
            else
                return true;
        }
        static bool checkeEmpty(string check)
        {
            if (check == "")
            {
                return true;
            }
            else
                return false;
        }
        static bool checkSpace(string check)
        {
            for (int x = 0; check[x+1] != '\0'; x++)
            {
                int num = check[x];
                if (num == 32)
                {
                    return true;
                }
            }
            return false;
        }

        static void printaAeroplane()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t__        __   _                            _          ____  _    ");
            Console.WriteLine("\t\t\t\t\\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___   / ___|| | ___   _ ");
            Console.WriteLine("\t\t\t\t \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  \\___ \\| |/ / | | |   ");
            Console.WriteLine("\t\t\t\t  \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) |  ___) |   <| |_| |  ");
            Console.WriteLine("\t\t\t\t__ \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  |____/|_|\\_\\__,  |  ");

            Console.WriteLine("\t\t\t\t\\ \\      / (_)_ __   __ _ ___     / \\  (_)_ __| (_)_ __   ___  ___ |___ /  ");

            Console.WriteLine("\t\t\t\t \\ \\ /\\ / /| | '_ \\ / _` / __|   / _ \\ | | '__| | | '_ \\ / _ \\/ __|      ");
            Console.WriteLine("\t\t\t\t  \\ V  V / | | | | | (_| \\__ \\  / ___ \\| | |  | | | | | |  __/\\__ \\      ");
            Console.WriteLine("\t\t\t\t   \\_/\\_/  |_|_| |_|\\__, |___/ /_/   \\_\\_|_|  |_|_|_| |_|\\___||___/     ");
            Console.WriteLine("\t\t\t\t                   |___/                                                ");
        }


        static bool checkstring(string check)
        {
            for (int x = 0; check[x] != '\0'; x++)
            {
                int num = check[x];
                if (num == 48 || num == 49 || num == 50 || num == 51 || num == 52 || num == 53 || num == 54 || num == 55 || num == 56 || num == 57)
                {
                    return true;
                }
            }
            return false;
        }
        static void signUpinterface()
        {

            Console.WriteLine("\t\t\t\t\t\t\t ____  _               _   _         __  __   ");
            Console.WriteLine("\t\t\t\t\t\t\t/ ___|(_) __ _ _ __   | | | |_ __   |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t\\___ \\| |/ _` | '_ \\  | | | | '_ \\  | |\\/| |/ _ \\ '_ \\| | | |  ");
            Console.WriteLine("\t\t\t\t\t\t\t ___) | | (_| | | | | | |_| | |_) | | |  | |  __/ | | | |_| |         ");
            Console.WriteLine("\t\t\t\t\t\t\t|____/|_|\\__, |_| |_|  \\___/| .__/  |_|  |_|\\___|_| |_|\\__,_|        ");
            Console.WriteLine("\t\t\t\t\t\t\t         |___/              |_|                                      "  );
        }
        static void signininterface()
        {

            Console.WriteLine("\t\t\t\t\t\t\t ____  _               ___         __  __     ");
            Console.WriteLine("\t\t\t\t\t\t\t/ ___|(_) __ _ _ __   |_ _|_ __   |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t\\___ \\| |/ _` | '_ \\   | || '_ \\  | |\\/| |/ _ \\ '_ \\| | | |  ");
            Console.WriteLine("\t\t\t\t\t\t\t ___) | | (_| | | | |  | || | | | | |  | |  __/ | | | |_| |       ");
            Console.WriteLine("\t\t\t\t\t\t\t|____/|_|\\__, |_| |_| |___|_| |_| |_|  |_|\\___|_| |_|\\__,_|   ");
            Console.WriteLine("\t\t\t\t\t\t\t         |___/                                                 ");
            Console.WriteLine();
        }
        static void adminMenu()
        {

            Console.WriteLine("\t\t\t\t\t\t\t    _       _           _         __  __     ");
            Console.WriteLine("\t\t\t\t\t\t\t   / \\   __| |_ __ ___ (_)_ __   |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t  / _ \\ / _` | '_ ` _ \\| | '_ \\  | |\\/| |/ _ \\ '_ \\| | | | ");
            Console.WriteLine("\t\t\t\t\t\t\t / ___ \\ (_| | | | | | | | | | | | |  | |  __/ | | | |_| |  ");
            Console.WriteLine("\t\t\t\t\t\t\t/_/   \\_\\__,_|_| |_| |_|_|_| |_| |_|  |_|\\___|_| |_|\\__,_|   ");
            Console.WriteLine();
        }
        static void customerMenu()
        {

            Console.WriteLine("\t\t\t\t\t\t\t  ____          _                                 __  __    ");
            Console.WriteLine("\t\t\t\t\t\t\t / ___|   _ ___| |_ ___  _ __ ___   ___ _ __     |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t| |  | | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__|    | |\\/| |/ _ \\ '_ \\| | | |");
            Console.WriteLine("\t\t\t\t\t\t\t| |__| |_| \\__ \\ || (_) | | | | | |  __/ |       | |  | |  __/ | | | |_| | ");
            Console.WriteLine("\t\t\t\t\t\t\t \\____\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|       |_|  |_|\\___|_| |_|\\__,_| ");
            Console.WriteLine();
        }
        static void managerMenu()
        {

            Console.WriteLine("\t\t\t\t\t\t\t __  __                                        __  __       ");
            Console.WriteLine("\t\t\t\t\t\t\t|  \\/  | __ _ _ __   __ _  __ _  ___ _ __     |  \\/  | ___ _ __  _   _ ");
            Console.WriteLine("\t\t\t\t\t\t\t| |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '__|    | |\\/| |/ _ \\ '_ \\| | | | ");
            Console.WriteLine("\t\t\t\t\t\t\t| |  | | (_| | | | | (_| | (_| |  __/ |       | |  | |  __/ | | | |_| |  ");
            Console.WriteLine("\t\t\t\t\t\t\t|_|  |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_|       |_|  |_|\\___|_| |_|\\__,_| ");
            Console.WriteLine("\t\t\t\t\t\t\t                         |___/                                          ");
            Console.WriteLine();
        }
        static void sheduleData(string[] departure, string[] arrival, int departurecount, int arrivalcount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\ShdeuleData.txt";
            StreamWriter file= new StreamWriter(path,false);
            
            for (int x = 0; x < departurecount; x++)
            {
                file.Write( departure[x] + ",");
            }
              file.WriteLine( departurecount + ",");
           
            ;
            for (int x = 0; x < arrivalcount; x++)
            {
                file.Write( arrival[x] + ",");
            }
            file .WriteLine(arrivalcount + ",");
            file.Flush();
            file.Close();
        }
        static void daysData(int departurecount, int arrivalcount)
        { string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\Daysdata.txt";

            StreamWriter file = new StreamWriter(path,false);
            file.Write(departurecount);
            file.Write(",");
            file.Write(arrivalcount);
            file.WriteLine(",");
            file.Flush();
            file.Close();
        }
        static void shedule(string[] departure, string[] arrival, ref int logincountfordeparture, ref int logincountForarrival)
        { ////cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            string arival;
            while (true)
            {

                Console.Write("Enter how many places of departure you want to give: ");


                arival = Console.ReadLine();
                if (check_int(arival) == true || checkeEmpty(arival) == true)
                {

                    Console.WriteLine("Invalid input. ");
                }
                else
                {
                    break;
                }
            }

            logincountfordeparture = int.Parse(arival);

            Console.WriteLine("Enter the places of departure: ");
            for (int x = 0; x < logincountfordeparture; x++)
            {
                while (true)
                {

                    departure[x] = Console.ReadLine();
                    if (checkeEmpty(departure[x]) == true || checkstring(departure[x]) == true)
                    {

                        Console.WriteLine("Invalid input. ");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string deprture;
            while (true)
            {

                Console.Write("Enter how many places of arrival you want to give: ");

                deprture = Console.ReadLine();
                if (check_int(deprture) == true || checkeEmpty(deprture) == true)
                {

                    Console.WriteLine("Invalid input. ");
                }
                else
                {
                    break;
                }
            }
            logincountForarrival = int.Parse(deprture);

            Console.WriteLine("Enter the places of arrival: ");
            for (int x = 0; x < logincountForarrival; x++)
            {
                while (true)
                {

                    arrival[x] = Console.ReadLine();
                    if (checkeEmpty(arrival[x]) == true || checkstring(arrival[x]) == true)
                    {

                        Console.WriteLine("Invalid input");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            sheduleData(departure, arrival, logincountfordeparture, logincountForarrival);
            daysData(logincountfordeparture, logincountForarrival);
        }
        static bool checkPlaces(string[] arrival, string[] departure, int logincount)
        {
            if (arrival[logincount] == departure[logincount])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool checkCNIC(string[] ID, string IDnum, int logincount)
        {
            string path = "E:\\Semester 2\\Lab 1\\BusinessApp\\UsersData.txt";
             StreamReader file=new StreamReader(path);
            int x = 0;
            if (File.Exists(path))
            {
                string var;
                
                while((var=file.ReadLine())!=null) 
                {
                  
                    ID[x] = getField(var, 12);
                    x++;
                }
                file.Close();
            }
            
            for (int index = 0; index < x - 1; index++)
            {
                if (IDnum == ID[index])
                {
                    return true;
                }
            }

            return false;
        }
       static bool checkSpaces(string var)
        {
            int num = 0;
            for (int x = 0; var[x] != '\0'; x++)
            {
                num = x;
            }
            if (var[0] == ' ' || var[num] == ' ' || var[0] == '\0') 
            {
                return true;
            }

            return false;
        }
    }
}
      
            
