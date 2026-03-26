namespace HW8
{
    public class Student
    {
        public string Name { get; set; }
        public float Score { get; set; }

        public Student(string name, float score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Name} ({Score})";
        }
    }
}