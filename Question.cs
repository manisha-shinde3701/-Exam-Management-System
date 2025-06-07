using System.ComponentModel.DataAnnotations;

public class Question
{
    [Key] // This attribute specifies that this is the primary key
    public int Qid { get; set; } // Replace 'QId' with your actual primary key property name

    // Other properties
    public string QSet { get; set; }
    public int QNo { get; set; }
    public string question { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string ans { get; set; }
}
