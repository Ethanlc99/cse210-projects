using System.Reflection.Metadata;

class ScriptureLibrary
{

    private Dictionary<List<string>, string> _scriptDict = new Dictionary<List<string>, string>()
    {
         // New Testament (KJV)
            { new List<string> {"John", "14", "6"}, "Jesus saith unto him, I am the way, the truth, and the life: no man cometh unto the Father, but by me." },
            { new List<string> {"Matthew", "28", "19", "20"}, "Go ye therefore, and teach all nations, baptizing them in the name of the Father, and of the Son, and of the Holy Ghost: Teaching them to observe all things whatsoever I have commanded you: and, lo, I am with you alway, even unto the end of the world. Amen." },
            {new List<string> {"Matthew", "5", "16"}, "Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."},
            {new List<string> {"John", "3", "16"}, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."},
            { new List<string> {"Ephesians", "2", "8", "9"}, "For by grace are ye saved through faith; and that not of yourselves: it is the gift of God: Not of works, lest any man should boast." },
            { new List<string> {"Matthew", "6", "33"}, "But seek ye first the kingdom of God, and his righteousness; and all these things shall be added unto you." },

            // Old Testament (KJV)
            { new List<string> {"Genesis", "1", "1"}, "In the beginning God created the heaven and the earth." },
            { new List<string> {"Psalm", "23", "1"}, "The Lord is my shepherd; I shall not want." },
            { new List<string> {"Proverbs", "3", "5", "6"}, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths." },
            { new List<string> {"Isaiah", "53", "5"}, "But he was wounded for our transgressions, he was bruised for our iniquities: the chastisement of our peace was upon him; and with his stripes we are healed." },

            // Book of Mormon
            { new List<string> {"2 Nephi", "2", "25"}, "Adam fell that men might be; and men are, that they might have joy." },
            { new List<string> {"Alma", "32", "21"}, "And now as I said concerning faith - faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true." },
            { new List<string> {"Mosiah", "18", "9"}, "Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death, that ye may be redeemed of God, and be numbered with those of the first resurrection, that ye may have eternal life." },
            { new List<string> {"Moroni", "10", "4", "5"}, "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things." },
            

            // Doctrine and Covenants
            { new List<string> {"Doctrine and Covenants", "58", "27"}, "Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness." },
            { new List<string> {"Doctrine and Covenants", "88", "118"}, "And as all have not faith, seek ye diligently and teach one another words of wisdom; yea, seek ye out of the best books words of wisdom; seek learning, even by study and also by faith." },
            { new List<string> {"Doctrine and Covenants", "130", "22", "23"}, "The Father has a body of flesh and bones as tangible as man’s; the Son also; but the Holy Ghost has not a body of flesh and bones, but is a personage of Spirit. Were it not so, the Holy Ghost could not dwell in us." },
            { new List<string> {"Doctrine and Covenants", "89", "18", "21"}, "And all saints who remember to keep and do these sayings, walking in obedience to the commandments, shall receive health in their navel and marrow to their bones; And shall find wisdom and great treasures of knowledge, even hidden treasures; And shall run and not be weary, and shall walk and not faint. And I, the Lord, give unto them a promise, that the destroying angel shall pass by them, as the children of Israel, and not slay them. Amen." },
            
            // Pearl of Great Price
            { new List<string> {"Moses", "1", "39"}, "For behold, this is my work and my glory - to bring to pass the immortality and eternal life of man." },
            { new List<string> {"Abraham", "3", "22", "23"}, "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones; And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born." },
            { new List<string> {"Abraham", "3", "19"}, "And the Lord said unto me: These two facts do exist, that there are two spirits, one being more intelligent than the other; there shall be another more intelligent than they; I am the Lord thy God, I am more intelligent than they all." },
            { new List<string> {"Moses", "1", "33"}, "And worlds without number have I created; and I also created them for mine own purpose; and by the Son I created them, which is mine Only Begotten." }
    };


    public string GetScripture(List<string> key)
    {
    string value = null;
        foreach (var kvp in _scriptDict)
        {
            if (kvp.Key.SequenceEqual(key))
            {
                value = kvp.Value;
                return value;
            }
        }

        if (value != null)
            Console.WriteLine(value);
        else
            Console.WriteLine("Scripture not found.");

        return "No Scripture Found";
    }

    public List<List<string>> GetAllKeys()
    {
        List<List<string>> keys = new List<List<string>>();
        foreach (List<string> key in _scriptDict.Keys)
        {
            keys.Add(key);
        }
        return keys;
    }

    public string GetReference(List<string> key)
    {
        string reference = string.Join(" ",key);

        return reference;
    }


}