namespace Multithreading;

using System.Threading;
using System;

class MatrixMultiplication{
    public static void Main(){}

    public static int[,] SequentialMult(int[,] matA, int[,] matB){
        if(matA.GetLength(1) != matB.GetLength(0)){
            throw new Exception("Dimensions incompatible");
        }

        int dim = matA.GetLength(1);

        int[,] matC = new int[matA.GetLength(0), matB.GetLength(1)];

        for(int row = 0; row < matC.GetLength(0); row++){
            for(int col = 0; col < matC.GetLength(1); col++){
                for (int i = 0; i < dim; i++){
                    matC[row, col] += matA[row, i] * matB[i, col];
                }
            }
        }

        return matC;
    }

    public static int[,] ParallelMult(int[,] matA, int[,] matB, int numThreads){
        throw new NotImplementedException();
    }

}