from abc import ABC, abstractmethod
import math

class TEquation(ABC):
    
    def __init__(self, *coefficients):
        self.__coefficients = coefficients
        pass

    def GetCoefficients(self):
        return self.__coefficients

    def GetEquation(self):
        return self._equation

    @abstractmethod
    def _SetEquation(self):
        pass

    @abstractmethod
    def HaveAnyRoots(self):
        pass

    @abstractmethod
    def IsRoot(self, numToCheck):
        pass

    @abstractmethod
    def FindRoot(self):
        pass
    pass


class LinearEquation(TEquation):

    def __init__(self, *coefficients):
        TEquation.__init__(self, coefficients)
        self.__a = coefficients[0]
        self.__b = coefficients[1]
        self._SetEquation()
        pass

    def _SetEquation(self):
        if self.__b < 0:
            self._equation = str(self.__a) + "x - " + str(abs(self.__b)) + " = 0"
        else:
            self._equation = str(self.__a) + "x + " + str(self.__b) + " = 0"
        pass

    def HaveAnyRoots(self):
        if (self.__a == 0 and self.__b == 0): return True
        elif (self.__a == 0 and (not self.__b == 0)): return False
        else: return True

    def IsRoot(self, numToCheck):
        if (not self.HaveAnyRoots()): return False
        sum : float = self.__a * numToCheck + self.__b
        return int(sum) == 0

    def FindRoot(self):
        root = float(-self.__b / self.__a)
        return root
    pass


class QuadraticEquation(TEquation):

    def __init__(self, *coefficients):
        TEquation.__init__(self, coefficients)
        self.__a = coefficients[0]
        self.__b = coefficients[1]
        self.__c = coefficients[2]
        self.__D = math.pow(self.__b, 2) - 4 * self.__a * self.__c
        self._SetEquation()
        pass

    def _SetEquation(self):
        if (self.__b < 0 and self.__c < 0): self._equation = "{0}x^2 - {1}x - {2} = 0".format(self.__a, abs(self.__b), abs(self.__c))
        elif (self.__b >= 0 and self.__c < 0): self._equation = "{0}x^2 + {1}x - {2} = 0".format(self.__a, self.__b, abs(self.__c))
        elif (self.__b < 0 and self.__c >= 0): self._equation = "{0}x^2 - {1}x + {2} = 0".format(self.__a, abs(self.__b), self.__c)
        else: self._equation = "{0}x^2 + {1}x + {2} = 0".format(self.__a, self.__b, self.__c)
        pass

    def HaveAnyRoots(self):
        if (self.__D >= 0): return True
        else: return False

    def IsRoot(self, numToCheck):
        if (not self.HaveAnyRoots()): return False
        sum : float = self.__a * math.pow(numToCheck, 2) + self.__b * numToCheck + self.__c
        return int(sum) == 0

    def FindRoot(self):
        if (self.__D == 0):
            root = float(-self.__b / (2 * self.__a))
            return [root]
        if (self.__D > 0):
            root1 = float((-self.__b + math.sqrt(self.__D)) / (2 * self.__a))
            root2 = float((-self.__b - math.sqrt(self.__D)) / (2 * self.__a))
            return [root1, root2]
    pass