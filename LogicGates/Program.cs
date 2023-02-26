// See https://aka.ms/new-console-template for more information
Console.WriteLine("Logic Gates");


double[][] datain = new double[][]
{
                new double[]{0,0},
                new double[]{0,1},
                new double[]{1,0},
                new double[]{1,1}
};

Console.WriteLine("Training OR");

double[] dataoutOR = new double[]
{
                0,
                1,
                1,
                1
};

var orweights=LogicGates.Perceptron.Train(datain, dataoutOR);

Console.WriteLine("Training AND");

double[] dataoutAND = new double[]
{
                0,
                0,
                0,
                1
};

var andweights=LogicGates.Perceptron.Train(datain, dataoutAND);

Console.WriteLine("Training NOR");

double[] dataoutNOR = new double[]
{
                1,
                0,
                0,
                0
};

var norweights=LogicGates.Perceptron.Train(datain, dataoutNOR);

Console.WriteLine("Training NAND");

double[] dataoutNAND = new double[]
{
                1,
                1,
                1,
                0
};

var nandweights=LogicGates.Perceptron.Train(datain, dataoutNAND);


Console.WriteLine("XOR NN - https://es.wikipedia.org/wiki/Puerta_XOR");


var nandneuron = new LogicGates.Perceptron(nandweights);
var andneuron = new LogicGates.Perceptron(andweights);
var orneuron = new LogicGates.Perceptron(orweights);

for (var i = 0; i < datain.Length; i++)
{
    var curin = datain[i];

    var o1 = nandneuron.Compute(curin[0], curin[1]);
    var o2 = orneuron.Compute(curin[0], curin[1]);

    var output = andneuron.Compute(o1, o2);

    Console.WriteLine($"{curin[0]} {curin[1]} - {output}");


}


Console.WriteLine("Training NOT");
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
var notneuron = new LogicGates.Perceptron(notweights);

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
                new double[]{0,0,0,1},
                new double[]{0,0,1,0},
                new double[]{0,0,1,1},
                new double[]{0,1,0,0},
                new double[]{0,1,0,1},
                new double[]{0,1,1,0},
                new double[]{0,1,1,1},
                new double[]{1,0,0,0},
                new double[]{1,0,0,1},
                new double[]{1,0,1,0},
                new double[]{1,0,1,1},
                new double[]{1,1,0,0},
                new double[]{1,1,0,1},
                new double[]{1,1,1,0},
                new double[]{1,1,1,1},
};

Console.WriteLine("a b | c d || r0 r1 r2");

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

    var r0 =orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(orneuron.Compute(r0_0, r0_1), r0_2),r0_3),r0_4),r0_5);

    Console.WriteLine($"{a} {b} | {c} {d} || {r0} r1 r2");
}


Console.ReadLine(); 