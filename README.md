# HW: Multithreaded Matrix Multiplication

1 Task Point

## Git Setup

To download the skeleton code for the homework assignment, use the following commands:

```bash
git clone https://github.com/CSC-3380-Class-Code/HW-Multithreaded-Matrix-Multiplication
```

Make sure .NET 9.0 SDK is installed: https://dotnet.microsoft.com/en-us/download/dotnet/9.0

Background Info / Helpful Links:
-	https://www.mathsisfun.com/algebra/matrix-multiplying.html
-	https://learn.microsoft.com/en-us/dotnet/standard/threading/using-threads-and-threading#how-to-create-and-start-a-new-thread
-	https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-9.0
-	https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadpool?view=net-9.0

## NOTE:
The first build should have errors pertaining to CS0021 and CS0019. These errors mean that the functions haven’t been made yet. Aside from these errors, the function to implement throws a Not Implemented error.

Also, for this assignment, the only file you are adding code to is “./Multithreading/Program.cs”. Furthermore, whenever I refer to the “codespace”, I am referring to the “./Multithreading/” folder.

## Assignment

Provided to you is a functions to multiply matrices sequentially. Your task is to implement the

```cs
int[,] ParallelMult(int[,] matA, int[,] matB, int numThreads)
```

method in addition to any other methods to help you achieve the full implementation.

To fully implement the ParallelMult function, you must program parallelized matrix multiplication using a thread pool. The function takes in 3 parameters and returns the calculated matrix.

- int[,] matA: an n by m matrix to be multiplied to matB
- int[,] matB: an m by r matrix to be multiplied to matA
- int numThreads: the min and max thread count to be used in the SetMaxThreads method of the thread pool.
The return value should be the result of matA*matB.

Given that parallelization allows for more work to be done, there is also the expectation that the parallel version will compute faster. This is reflected in the unit tests.

Any questions about the assignment feel free to contact me via Discord, email, or in-person.

## Testing

Whilst in the codespace, use command ‘dotnet test’ to run the unit test file.

## Submission

Upload only the Program.cs from the Multithreading folder to Moodle

## Grading

This assignment is worth 1 task point.

Part of the skeleton code you download is an NUnit test file. For this to count for the task point, all tests must be passed.
