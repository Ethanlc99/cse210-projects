using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Algorithm's Intern";
        job1._company = "IMSAR";
        job1._startYear = 2022;
        job1._endYear = 2023;

        Job job2 = new Job();

        job2._jobTitle = "Automotive Engineer";
        job2._company = "Tesla";
        job2._startYear = 2010;
        job2._endYear = 2015;

        Resume resume1 = new Resume();

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._name = "Joe Biden";

        resume1.Display();


        // job1.Display();
        // job2.Display();
    }
}