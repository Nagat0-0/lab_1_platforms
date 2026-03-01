using System;

public class ResearchTeam
{
    private string _researchTopic;
    private string _organization;
    private int _registrationNumber;
    private TimeFrame _duration;
    private Paper[] _publications;

    public ResearchTeam(string researchTopic, string organization, int registrationNumber, TimeFrame duration)
    {
        _researchTopic = researchTopic;
        _organization = organization;
        _registrationNumber = registrationNumber;
        _duration = duration;
        _publications = new Paper[0]; 
    }

    public ResearchTeam()
    {
        _researchTopic = "Невідома тема";
        _organization = "Невідома організація";
        _registrationNumber = 0;
        _duration = TimeFrame.Year;
        _publications = new Paper[0];
    }

    public string ResearchTopic
    {
        get { return _researchTopic; }
        set { _researchTopic = value; }
    }

    public string Organization
    {
        get { return _organization; }
        set { _organization = value; }
    }

    public int RegistrationNumber
    {
        get { return _registrationNumber; }
        set { _registrationNumber = value; }
    }

    public TimeFrame Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public Paper[] Publications
    {
        get { return _publications; }
        set { _publications = value; }
    }

    public Paper? LatestPaper
    {
        get
        {
            if (_publications == null || _publications.Length == 0)
            {
                return null;
            }

            Paper latest = _publications[0];
            
            for (int i = 1; i < _publications.Length; i++)
            {
                if (_publications[i].PublicationDate > latest.PublicationDate)
                {
                    latest = _publications[i];
                }
            }
            return latest;
        }
    }

    public bool this[TimeFrame index]
    {
        get
        {
            return _duration == index;
        }
    }

    public void AddPapers(params Paper[] newPapers)
    {
        if (newPapers == null || newPapers.Length == 0) return;

        int oldLength = _publications.Length;

        Paper[] updatedPapers = new Paper[oldLength + newPapers.Length];

        for (int i = 0; i < oldLength; i++)
        {
            updatedPapers[i] = _publications[i];
        }

        for (int i = 0; i < newPapers.Length; i++)
        {
            updatedPapers[oldLength + i] = newPapers[i];
        }

        _publications = updatedPapers;
    }

    public override string ToString()
    {
        string info = $"Дослідження: '{ResearchTopic}' ({Organization}), Реєстр. №: {RegistrationNumber}, Тривалість: {Duration}\nСписок публікацій:\n";
        
        if (_publications.Length == 0)
        {
            info += "  Публікацій ще немає.\n";
        }
        else
        {
            foreach (Paper p in _publications) 
            {
                info += $"  - {p.ToString()}\n";
            }
        }
        return info;
    }

    public virtual string ToShortString()
    {
        return $"Дослідження: '{ResearchTopic}' ({Organization}), Реєстр. №: {RegistrationNumber}, Тривалість: {Duration}";
    }
}