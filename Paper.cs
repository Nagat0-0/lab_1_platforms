public class Paper
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime PublicationDate { get; set; }

    public Paper(string title, Person author, DateTime publicationDate)
    {
        Title = title;
        Author = author;
        PublicationDate = publicationDate;
    }

    public Paper(): this("Без назви", new Person(), DateTime.Now) 
    { 
    }

    public override string ToString() => $"Публікація: '{Title}', Автор: {Author.ToShortString()}, Дата: {PublicationDate.ToShortDateString()}";
}