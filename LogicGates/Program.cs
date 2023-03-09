
using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Neural :-)")
        .LeftJustified()
        .Color(Color.LightGreen));
AnsiConsole.Write(
    new FigletText("Logic Gates")
        .LeftJustified()
        .Color(Color.White));


double[][] datain = new double[][]
{
                new double[]{0,0},
                new double[]{0,1},
                new double[]{1,0},
                new double[]{1,1}
};
AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]Training OR[/]"));

double[] dataoutOR = new double[]
{
                0,
                1,
                1,
                1
};

var orweights=LogicGates.Perceptron.Train(datain, dataoutOR);

WriteWeigths(orweights);
var orneuron = new LogicGates.Perceptron(orweights);
Test(datain,orneuron);

AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]Training AND[/]"));



double[] dataoutAND = new double[]
{
                0,
                0,
                0,
                1
};

var andweights=LogicGates.Perceptron.Train(datain, dataoutAND);
WriteWeigths(andweights);
var andneuron = new LogicGates.Perceptron(andweights);
Test(datain, andneuron);

AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]Training NOR[/]"));



double[] dataoutNOR = new double[]
{
                1,
                0,
                0,
                0
};

var norweights=LogicGates.Perceptron.Train(datain, dataoutNOR);
WriteWeigths(norweights);
var norneuron = new LogicGates.Perceptron(norweights);
Test(datain, norneuron);

AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]Training NAND[/]"));


double[] dataoutNAND = new double[]
{
                1,
                1,
                1,
                0
};

var nandweights=LogicGates.Perceptron.Train(datain, dataoutNAND);
WriteWeigths(nandweights);
var nandneuron = new LogicGates.Perceptron(nandweights);

Test(datain, nandneuron);

AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]XOR NN [/] - [bold white on blue]https://es.wikipedia.org/wiki/Puerta_XOR [/]"));


var table = new Table();

// Add some columns
table.AddColumn(new TableColumn("i1").Centered());
table.AddColumn(new TableColumn("i2").Centered());
table.AddColumn(new TableColumn("[green]o[/]").Centered());

AnsiConsole.WriteLine();
for (var i = 0; i < datain.Length; i++)
{
    var curin = datain[i];

    var o1 = nandneuron.Compute(curin[0], curin[1]);
    var o2 = orneuron.Compute(curin[0], curin[1]);

    var output = andneuron.Compute(o1, o2);
    table.AddRow($"{curin[0]}", $"{curin[1]}", $"[green]{output}[/]");

}
var panel = new Panel(table);
panel.Header("Test");
AnsiConsole.Write(panel);


AnsiConsole.WriteLine();
AnsiConsole.Write(new Markup("[bold lime]Training NOT[/]"));


datain = new double[][]
{
                new double[]{0,0},
                new double[]{1,1}
};
double[] dataoutNOT = new double[]
{
                1,
                0,

};

var notweights = LogicGates.Perceptron.Train(datain, dataoutNOT);
WriteWeigths(notweights);

var notneuron = new LogicGates.Perceptron(notweights);
Test(datain, notneuron);
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();




//  Two digit adder
//
//  a b | c d || r0 r1 r2
//  ----|-----||---------
//  0 0 | 0 0 || 0  0  0  = 0
//  0 1 | 0 0 || 0  0  1  = 1
//  1 0 | 0 0 || 0  0  1  = 2
//  1 1 | 0 0 || 0  1  1  = 3
//  0 0 | 0 1 || 0  0  1  = 1
//  0 1 | 0 1 || 0  1  0  = 2
//  1 0 | 0 1 || 0  1  1  = 3
//  1 1 | 0 1 || 1  0  0  = 4
//  0 0 | 1 0 || 0  1  0  = 2
//  0 1 | 1 0 || 0  1  1  = 3
//  1 0 | 1 0 || 1  0  0  = 4
//  1 1 | 1 0 || 1  0  1  = 5
//  0 0 | 1 1 || 0  1  1  = 3
//  0 1 | 1 1 || 1  0  0  = 4
//  1 0 | 1 1 || 1  0  1  = 5
//  1 1 | 1 1 || 1  1  0  = 6
//                _             _       _                 _     _                     _
//  r0 = (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d)
//                _   _     _       _             _   _         _   _       _     _           _     _   _
//  r1 = (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d)
//                              _       _     _   _       _             _         _       _             _   _   _     _   _   _   _
//  r2 = (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d)



datain = new double[][]
{
                new double[]{0,0,0,0},
                new double[]{0,1,0,0},
                new double[]{1,0,0,0},
                new double[]{1,1,0,0},
                new double[]{0,0,0,1},
                new double[]{0,1,0,1},
                new double[]{1,0,0,1},
                new double[]{1,1,0,1},
                new double[]{0,0,1,0},
                new double[]{0,1,1,0},
                new double[]{1,0,1,0},
                new double[]{1,1,1,0},
                new double[]{0,0,1,1},
                new double[]{0,1,1,1},
                new double[]{1,0,1,1},
                new double[]{1,1,1,1},
};

Console.WriteLine("a b | c d || r0 r1 r2");
Console.WriteLine("----|-----||---------");

for (var i = 0; i < datain.Length; i++)
{
    var a = datain[i][0];
    var b = datain[i][1];
    var c = datain[i][2];
    var d = datain[i][3];
    var na = notneuron.Compute(a, a);
    var nb = notneuron.Compute(b, b);
    var nc = notneuron.Compute(c, c);
    var nd = notneuron.Compute(d, d);

    //                _             _       _                 _     _                     _
    //  r0 = (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d)

    var r0_0 = andneuron.Compute(andneuron.Compute(andneuron.Compute( a,  b),nc),  d);
    var r0_1 = andneuron.Compute(andneuron.Compute(andneuron.Compute( a, nb), c), nd);
    var r0_2 = andneuron.Compute(andneuron.Compute(andneuron.Compute( a,  b), c), nd);
    var r0_3 = andneuron.Compute(andneuron.Compute(andneuron.Compute(na,  b), c),  d);
    var r0_4 = andneuron.Compute(andneuron.Compute(andneuron.Compute( a, nb), c),  d);
    var r0_5 = andneuron.Compute(andneuron.Compute(andneuron.Compute( a,  b), c),  d);

    var r0 = orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(r0_0, r0_1), r0_2),r0_3),r0_4),r0_5);

    //                _   _     _       _             _   _         _   _       _     _           _     _   _
    //  r1 = (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d) + (a * b * c * d)

    var r1_0 = andneuron.Compute(andneuron.Compute(andneuron.Compute(a, b), nc), nd);
    var r1_1 = andneuron.Compute(andneuron.Compute(andneuron.Compute(na, b), nc), d);
    var r1_2 = andneuron.Compute(andneuron.Compute(andneuron.Compute(a, nb), nc), d);
    var r1_3 = andneuron.Compute(andneuron.Compute(andneuron.Compute(na, nb), c), nd);
    var r1_4 = andneuron.Compute(andneuron.Compute(andneuron.Compute(na, b), c), nd);
    var r1_5 = andneuron.Compute(andneuron.Compute(andneuron.Compute(na, nb), c), d);
    var r1_6 = andneuron.Compute(andneuron.Compute(andneuron.Compute(a, b), c), d);
    var r1 =orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(r1_0, r1_1), r1_2), r1_3), r1_4), r1_5),r1_6);

    //                              _       _     _   _       _             _         _       _             _   _   _     _   _   _   _
    //  r2 = (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d) * (a + b + c + d)

    var r2_0 = orneuron.Compute(orneuron.Compute(orneuron.Compute(a, b), c), d);
    var r2_1 = orneuron.Compute(orneuron.Compute(orneuron.Compute(a, nb), c), nd);
    var r2_2 = orneuron.Compute(orneuron.Compute(orneuron.Compute(na, nb), c), nd);
    var r2_3 = orneuron.Compute(orneuron.Compute(orneuron.Compute(a, b), nc), d);
    var r2_4 = orneuron.Compute(orneuron.Compute(orneuron.Compute(na, b), nc), d);
    var r2_5 = orneuron.Compute(orneuron.Compute(orneuron.Compute(a, nb), nc), nd);
    var r2_6 = orneuron.Compute(orneuron.Compute(orneuron.Compute(na, nb), nc), nd);
    var r2 = andneuron.Compute(andneuron.Compute(andneuron.Compute(andneuron.Compute(andneuron.Compute(andneuron.Compute(r2_0, r2_1), r2_2), r2_3), r2_4), r2_5), r2_6);




    Console.WriteLine($"{a} {b} | {c} {d} ||  {r0}  {r1}  {r2}");
}


Console.ReadLine();

void WriteWeigths(double[] weights)
{
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Markup($"[bold gold3 on red3]Weigths:[/] [bold black on white]{weights[0]} {weights[1]} {weights[2]}[/]"));
    AnsiConsole.WriteLine();

}


void Test(double[][] dataIn, LogicGates.Perceptron neunet)
{

    
    //Console.WriteLine("Test");

    var table = new Table();

    // Add some columns
    table.AddColumn(new TableColumn("i1").Centered());
    table.AddColumn(new TableColumn("i2").Centered());
    table.AddColumn(new TableColumn("[green]o[/]").Centered());





    for (var i = 0; i < dataIn.Length; i++)
    {
        var curin = dataIn[i];
        // Add some rows
        table.AddRow($"{curin[0]}", $"{curin[1]}",$"[green]{neunet.Compute(curin[0], curin[1])}[/]");
        
    }
    var panel = new Panel(table);
    panel.Header("Test");
    AnsiConsole.Write(panel);

}