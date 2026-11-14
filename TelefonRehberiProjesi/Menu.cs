namespace TelefonRehberiProjesi;

public class Menu
{
    private readonly PhoneBook phoneBook;

    public Menu(PhoneBook phoneBook)
    {
        this.phoneBook = phoneBook;
    }

    public void Run()
    {
        while (true)
        {
            ShowMainMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    DeleteContact();
                    break;
                case "3":
                    UpdateContact();
                    break;
                case "4":
                    ListContacts();
                    break;
                case "5":
                    SearchContacts();
                    break;
                case "0":
                    Console.WriteLine("Programdan cikiliyor...");
                    return;
                default:
                    Console.WriteLine("Gecersiz secim. Tekrar deneyiniz.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void ShowMainMenu()
    {
        Console.WriteLine("TELEFON REHBERI");
        Console.WriteLine(new string('*', 40));
        Console.WriteLine("(1) Yeni numara kaydet");
        Console.WriteLine("(2) Varolan numarayi sil");
        Console.WriteLine("(3) Varolan numarayi guncelle");
        Console.WriteLine("(4) Rehberi listele");
        Console.WriteLine("(5) Rehberde arama yap");
        Console.WriteLine("(0) Cikis");
        Console.Write("Lutfen yapmak istediginiz islemi seciniz: ");
    }

    private void AddContact()
    {
        Console.WriteLine("\nYENI NUMARA KAYDET");
        string firstName = ReadRequired("Lutfen isim giriniz: ");
        string lastName = ReadRequired("Lutfen soyisim giriniz: ");
        string phoneNumber = ReadRequired("Lutfen telefon numarasi giriniz: ");

        phoneBook.AddContact(new Contact(firstName, lastName, phoneNumber));
        Console.WriteLine("Kisi rehbere eklendi.");
    }

    private void DeleteContact()
    {
        while (true)
        {
            Console.Write("\nSilmek istediginiz kisinin adini ya da soyadini giriniz: ");
            string keyword = Console.ReadLine()?.Trim() ?? "";

            Contact? contact = phoneBook.FindByNameOrSurname(keyword);

            if (contact is null)
            {
                Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi.");
                Console.WriteLine("(1) Silmeyi sonlandir");
                Console.WriteLine("(2) Yeniden dene");
                Console.Write("Seciminiz: ");

                if (Console.ReadLine() == "1")
                    return;

                continue;
            }

            Console.WriteLine($"'{contact.FirstName} {contact.LastName}' isimli kisi silinmek uzere. Onayliyor musunuz? (y/n)");
            string confirmation = Console.ReadLine()?.Trim().ToLowerInvariant() ?? "";

            if (confirmation == "y")
            {
                phoneBook.RemoveContact(contact);
                Console.WriteLine("Kisi rehberden silindi.");
            }
            else
            {
                Console.WriteLine("Silme islemi iptal edildi.");
            }

            return;
        }
    }

    private void UpdateContact()
    {
        while (true)
        {
            Console.Write("\nGuncellemek istediginiz kisinin adini ya da soyadini giriniz: ");
            string keyword = Console.ReadLine()?.Trim() ?? "";

            Contact? contact = phoneBook.FindByNameOrSurname(keyword);

            if (contact is null)
            {
                Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi.");
                Console.WriteLine("(1) Guncellemeyi sonlandir");
                Console.WriteLine("(2) Yeniden dene");
                Console.Write("Seciminiz: ");

                if (Console.ReadLine() == "1")
                    return;

                continue;
            }

            Console.WriteLine("Bulunan kisi:");
            PrintContact(contact);

            Console.WriteLine("Yeni bilgileri giriniz:");
            contact.FirstName = ReadRequired("Yeni isim: ");
            contact.LastName = ReadRequired("Yeni soyisim: ");
            contact.PhoneNumber = ReadRequired("Yeni telefon numarasi: ");

            Console.WriteLine("Kisi bilgileri guncellendi.");
            return;
        }
    }

    private void ListContacts()
    {
        Console.WriteLine("\nRehber siralama secimi:");
        Console.WriteLine("(1) A-Z");
        Console.WriteLine("(2) Z-A");
        Console.Write("Seciminiz: ");

        string? choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Gecersiz secim.");
            return;
        }

        List<Contact> sortedContacts = phoneBook.GetSortedContacts(choice == "1");
        PrintContacts("TELEFON REHBERI", sortedContacts);
    }

    private void SearchContacts()
    {
        Console.WriteLine("\nArama yapmak istediginiz tipi seciniz:");
        Console.WriteLine("(1) Isim veya soyisime gore");
        Console.WriteLine("(2) Telefon numarasina gore");
        Console.Write("Seciminiz: ");

        string? choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Gecersiz secim.");
            return;
        }

        Console.Write("Aranacak kelime veya numara: ");
        string keyword = Console.ReadLine()?.Trim() ?? "";

        List<Contact> results = choice == "1"
            ? phoneBook.SearchByNameOrSurname(keyword)
            : phoneBook.SearchByPhoneNumber(keyword);

        PrintContacts("ARAMA SONUCLARI", results);
    }

    private static string ReadRequired(string message)
    {
        while (true)
        {
            Console.Write(message);
            string value = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Console.WriteLine("Bu alan bos birakilamaz.");
        }
    }

    private static void PrintContacts(string title, List<Contact> contacts)
    {
        Console.WriteLine("\n" + title);
        Console.WriteLine(new string('*', 40));

        if (contacts.Count == 0)
        {
            Console.WriteLine("Gosterilecek kayit bulunamadi.");
            return;
        }

        foreach (Contact contact in contacts)
        {
            PrintContact(contact);
            Console.WriteLine(new string('-', 25));
        }

        Console.WriteLine($"Toplam kayit: {contacts.Count}");
    }

    private static void PrintContact(Contact contact)
    {
        Console.WriteLine($"Isim: {contact.FirstName}");
        Console.WriteLine($"Soyisim: {contact.LastName}");
        Console.WriteLine($"Telefon Numarasi: {contact.PhoneNumber}");
    }
}
