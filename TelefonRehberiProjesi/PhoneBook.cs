namespace TelefonRehberiProjesi;

public class PhoneBook
{
    private readonly List<Contact> contacts = new();

    public PhoneBook()
    {
        AddContact(new Contact("Ahmet", "Yilmaz", "05321112233"));
        AddContact(new Contact("Ayse", "Demir", "05442223344"));
        AddContact(new Contact("Mehmet", "Kaya", "05553334455"));
        AddContact(new Contact("Fatma", "Celik", "05054445566"));
        AddContact(new Contact("Ali", "Sahin", "05365556677"));
    }

    public IReadOnlyList<Contact> Contacts => contacts.AsReadOnly();

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public Contact? FindByNameOrSurname(string keyword)
    {
        return contacts.FirstOrDefault(contact =>
            contact.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            contact.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    public List<Contact> SearchByNameOrSurname(string keyword)
    {
        return contacts.Where(contact =>
            contact.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            contact.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Contact> SearchByPhoneNumber(string keyword)
    {
        return contacts.Where(contact =>
            contact.PhoneNumber.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public bool RemoveContact(Contact contact)
    {
        return contacts.Remove(contact);
    }

    public List<Contact> GetSortedContacts(bool ascending)
    {
        IOrderedEnumerable<Contact> sorted = contacts
            .OrderBy(contact => contact.LastName, StringComparer.OrdinalIgnoreCase)
            .ThenBy(contact => contact.FirstName, StringComparer.OrdinalIgnoreCase);

        if (!ascending)
        {
            sorted = contacts
                .OrderByDescending(contact => contact.LastName, StringComparer.OrdinalIgnoreCase)
                .ThenByDescending(contact => contact.FirstName, StringComparer.OrdinalIgnoreCase);
        }

        return sorted.ToList();
    }
}
