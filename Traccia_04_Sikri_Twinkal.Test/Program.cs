using Traccia_04_Sikri_Twinkal.Test.Orm;
using Traccia_04_Sikri_Twinkal.Abstractions;


    List<IExample> examples = new List<IExample>();


    //examples.Add(new Repository());

    examples.Add(new EntityFramework());

//examples.Add(new Linq()); 


foreach (var example in examples)
{
    await example.RunExampleAsync();
}

Console.ReadLine();

