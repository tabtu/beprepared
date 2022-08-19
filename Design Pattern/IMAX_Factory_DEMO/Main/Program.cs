
using IMAX.Factory;
using IMAX.IProjector;

Console.WriteLine("Start");

#region Impl test code
//ITask aa = new IMAX.ProjectorA.TaskImpl();
//aa.Func();

//ITask bb = new IMAX.ProjectorB.TaskImpl();
//bb.Func();
#endregion



ITask projectInstance = new IMAX.ProjectorA.TaskImpl();  // predefine an instance, default as A
string className = "TaskImpl";  // define a static and shared classname for 2 packages

while (true)
{
    Console.WriteLine();
    Console.WriteLine("input 'Q' to quit.");
    Console.WriteLine("Please input the type of Projector (e.g. A or B) : ");
    string? input = Console.ReadLine();
    if (input == null)
        Console.WriteLine("EMPTY");
    else if (input == "Q")
        return;
    else if (input == "A")  // init instance as ProjectorA
        projectInstance = DataAccess.CreateProjectorInstance("A", className);
    else if (input == "B")  // init instance as ProjectorB
        projectInstance = DataAccess.CreateProjectorInstance("B", className);
    else
        Console.WriteLine("Not 'A' nor 'B', will keep instance as previous state, default is 'A'.");

    // call instance function
    projectInstance.Func();
}
