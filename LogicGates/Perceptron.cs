using System;
namespace LogicGates
{
	public class Perceptron
	{
		private double[] _inputs = new double[2];
        private double[] _weights_to_output = new double[2];
        private double _bias_to_output;
        private double learning_rate=1.0;

        public Perceptron()
        {
            InicializeWeights();
        }
        public Perceptron(double[] weights)
        {
            if (weights == null || weights.Length < 3) throw new ArgumentException(nameof(weights));
            _weights_to_output[0] = weights[0];
            _weights_to_output[1] = weights[1];
            _bias_to_output = weights[2];

        }

        private void InicializeWeights()
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);

  
            _weights_to_output[0] = random.NextDouble();
            _weights_to_output[1] = random.NextDouble();

            _bias_to_output = random.NextDouble();
        }

        public double Compute(double input0, double input1)
        {
            double result = 0.0;
           

            // to hidden2

            double output = input0 * _weights_to_output[0] + input1 * _weights_to_output[1] + _bias_to_output;


            result = output;

            return (result >= 0 ? 1:0);

        }

        public static double[] Train(double[][] dataIn, double[] dataOut)
        {

            var neunet = new Perceptron();


            double losserror = 1.0;

            while (losserror > 0.2)
            {


                for (var i = 0; i < dataIn.Length; i++)
                {
                    var curin = dataIn[i];
                    var curout = dataOut[i];

                    var result = neunet.Compute(curin[0], curin[1]);


                    double error = curout - result;
                    //Adjust
                    neunet._weights_to_output[0] += neunet.learning_rate * error * curin[0];
                    neunet._weights_to_output[1] += neunet.learning_rate * error * curin[1];
                    neunet._bias_to_output += neunet.learning_rate * error;



                    losserror += Math.Pow(error,2);


                    

                }

                losserror = losserror / dataOut.Length;
                Console.WriteLine($" {losserror.ToString("F2")}");

            }

            Console.WriteLine("Results:");

            for (var i = 0; i < dataIn.Length; i++)
            {
                var curin = dataIn[i];

                Console.WriteLine($"{curin[0]} {curin[1]} - {neunet.Compute(curin[0], curin[1])}");
            }

            Console.WriteLine("Weigths:");

            Console.WriteLine($"{neunet._weights_to_output[0]} {neunet._weights_to_output[1]} {neunet._bias_to_output}");



            return new double[] { neunet._weights_to_output[0], neunet._weights_to_output[1], neunet._bias_to_output };
        }

        

    }
}

