package org.example;


import org.junit.Test;
        import org.junit.runner.RunWith;
        import org.junit.runners.Parameterized;

        import java.util.Arrays;
        import java.util.Collection;

        import static org.junit.Assert.assertEquals;

@RunWith(Parameterized.class)
public class CalculatorTest {
    private double num1;
    private double num2;
    private char operation;
    private double expected;

    public CalculatorTest(double num1, double num2, char operation, double expected) {
        this.num1 = num1;
        this.num2 = num2;
        this.operation = operation;
        this.expected = expected;
    }

    @Parameterized.Parameters
    public static Collection<Object[]> data() {
        return Arrays.asList(new Object[][]{
                {1, 1, '+', 2},
                {-1, -1, '+', -2},
                {0, 0, '+', 0},
                {0.1, 1, '+', 1.1},
                {0.1, 0.1, '+', 0.2},

                {5, 5, '-', 0},
                {-7, -3, '-', -4},
                {0, 0, '-', 0},
                {0.1, 1, '-', -0.9},
                {0.7, 0.1, '-', 0.6},

                {2, 3, '*', 6},
                {-2, -3, '*', 6},
                {0, 3, '*', 0},
                {1.2, 2, '*', 2.4},
                {0.1, 0.1, '*', 0.01},

                {10, 5, '/', 2},
                {-10, -5, '/', 2},
                {5, 0.5, '/', 10},
                {0.5, 5, '/', 0.1}

        });
    }

    @Test
    public void testCalculator() {
        assertEquals(expected, Calculator.calculate(num1, num2, operation), 0.00001);
    }

    @Test(expected = IllegalArgumentException.class)
     public void testCalculatorException() {
         Calculator.calculate(1, 0, '/');
     }
}
