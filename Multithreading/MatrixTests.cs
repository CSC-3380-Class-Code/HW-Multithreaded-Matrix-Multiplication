namespace Multithreading
{
    [TestFixture]
    public class MatrixTests
    {
        const int small = 200;
        const int large = 1500;
        const int rectangle = 500;

        static int[,] smallSquare1 = new int[small,small];
        static int[,] smallSquare2 = new int[small,small];

        static int[,] smallRect1 = new int[small,rectangle];
        static int[,] smallRect2 = new int[rectangle, small];

        static int[,] largeSquare1 = new int[large,large];
        static int[,] largeSquare2 = new int[large,large];

        static int[,] largeRect1 = new int[large,rectangle];
        static int[,] largeRect2 = new int[rectangle,large];


        private static void PopulateMatrix(int[,] mat, Random rng){
            for(int row = 0; row < mat.GetLength(0); row++){
                for(int col = 0; col < mat.GetLength(1); col++){
                    mat[row, col] = rng.Next(1,100);
                }
            }
        }

        private static bool CheckMatrixEquality(int[,] mat1, int[,] mat2){
            if(mat1.GetLength(0) != mat2.GetLength(0)){
                return false;
            }
            if(mat1.GetLength(1) != mat2.GetLength(1)){
                return false;
            }

            for(int r = 0; r < mat1.GetLength(0); r++){
                for(int c = 0; c < mat1.GetLength(1); c++){
                    if(mat1[r,c] != mat2[r,c]){
                        return false;
                    }
                }
            }

            return true;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            Random rng = new Random();

            PopulateMatrix(smallSquare1, rng);
            PopulateMatrix(smallSquare2, rng);

            PopulateMatrix(smallRect1, rng);
            PopulateMatrix(smallRect2, rng);

            PopulateMatrix(largeSquare1, rng);
            PopulateMatrix(largeSquare2, rng);

            PopulateMatrix(largeRect1, rng);
            PopulateMatrix(largeRect2, rng);
        }

        [TestCase(8)]
        [TestCase(16)]
        public void TestSquareSmall(int numThreads)
        {
            int[,] sequential = MatrixMultiplication.SequentialMult(smallSquare1, smallSquare2);
            int[,] parallel = MatrixMultiplication.ParallelMult(smallSquare1, smallSquare2, numThreads);

            Assert.True(CheckMatrixEquality(sequential, parallel));
        }

        [TestCase(8)]
        [TestCase(16)]
        public void TestRectangularSmall(int numThreads)
        {
            int[,] sequential = MatrixMultiplication.SequentialMult(smallRect1, smallRect2);
            int[,] parallel = MatrixMultiplication.ParallelMult(smallRect1, smallRect2, numThreads);

            Assert.True(CheckMatrixEquality(sequential, parallel));
        }

        [TestCase(8)]
        [TestCase(16)]
        public void TestSquareLarge(int numThreads)
        {
            long seqMS;
            long paraMS;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] sequential = MatrixMultiplication.SequentialMult(largeSquare1, largeSquare2);
            watch.Stop();
            seqMS = watch.ElapsedMilliseconds;

            watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] parallel = MatrixMultiplication.ParallelMult(largeSquare1, largeSquare2, numThreads);
            watch.Stop();
            paraMS = watch.ElapsedMilliseconds;

            Assert.True(CheckMatrixEquality(sequential, parallel));
            Assert.True((double)paraMS/seqMS*100 < 70);
        }

        [TestCase(8)]
        [TestCase(16)]
        public void TestRectangularLarge(int numThreads)
        {
            long seqMS;
            long paraMS;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] sequential = MatrixMultiplication.SequentialMult(largeRect1, largeRect2);
            watch.Stop();
            seqMS = watch.ElapsedMilliseconds;

            watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] parallel = MatrixMultiplication.ParallelMult(largeRect1, largeRect2, numThreads);
            watch.Stop();
            paraMS = watch.ElapsedMilliseconds;

            Assert.True(CheckMatrixEquality(sequential, parallel));
            Assert.True((double)paraMS/seqMS*100 < 70);
        }
    }
}