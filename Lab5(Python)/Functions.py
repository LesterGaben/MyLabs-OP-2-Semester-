from Classes import LinearEquation, QuadraticEquation
import random
import numpy as np


def TaskWithLinearEquations(n):
    linearEquations = []
    print("\nLinear Equations:")
    for i in range(0, n):
        a = random.randint(-100, 100)
        b = random.randint(-100, 100)
        linearEquation = LinearEquation(a, b)
        linearEquations.append(linearEquation)
        print(linearEquation.GetEquation() + "   " + ("Have root" if linearEquation.HaveAnyRoots() else "No roots"))
        pass
    print("\nSum of linear equation's(that have roots) roots: " + str(GetSumOfLinearEquationRootsThatHaveRoots(linearEquations)))
    iOfLinearEquation = int(input("\nInput num of linear equation to check: ")) - 1
    numToCheckInLinearEquation = float(input("Input num to check: "))
    print("Num is a root: " + str(linearEquations[iOfLinearEquation].IsRoot(numToCheckInLinearEquation)))
    pass


def TaskWithQuadraticEquation(m):
    quadraticEquations = []
    print("\nQuadratic Equations:")
    for i in range(0, m):
        a = random.randint(-100, 100)
        b = random.randint(-100, 100)
        c = random.randint(-100, 100)
        quadraticEquation = QuadraticEquation(a, b, c)
        quadraticEquations.append(quadraticEquation)
        print(quadraticEquation.GetEquation() + "   " + ("Have root or roots" if quadraticEquation.HaveAnyRoots() else "No roots"))
        pass
    print("\nSum of quadratic equation's(that have roots) roots: " + str(GetSumOfQuadraticEquationRootsThatHaveRoots(quadraticEquations)))
    iOfQuadraticEquation = int(input("\nInput num of quadratic equation to check: ")) - 1
    numToCheckInQuadraticEquation = float(input("Input num to check: "))
    print("Num is a root: " + str(quadraticEquations[iOfQuadraticEquation].IsRoot(numToCheckInQuadraticEquation)))
    pass


def GetSumOfLinearEquationRootsThatHaveRoots(equations):
    equationsRootsSum = 0
    for equation in equations:
        if not equation.HaveAnyRoots():
            continue
        equationsRootsSum += equation.FindRoot()
        pass
    return equationsRootsSum


def GetSumOfQuadraticEquationRootsThatHaveRoots(equations):
    equationsRootsSum = 0
    for equation in equations:
        if not equation.HaveAnyRoots():
            continue
        temp = np.sum(equation.FindRoot())
        equationsRootsSum += temp
        pass
    return equationsRootsSum