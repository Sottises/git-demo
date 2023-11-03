package org.example;

import java.util.Scanner;

public class Calculator {
  public static double calculate(double num1, double num2, char operation)  {
      double result = 0;
        switch (operation) {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0) {
                    result = num1 / num2;
                } else {
                    System.out.println("Ошибка: деление на ноль!");
                    return result;
                }
                break;
            default:
                System.out.println("Ошибка: неверная операция!");

        }
        System.out.println("Результат: " + result);
      return result;
  }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Введите первое число:");
        double num1 = scanner.nextDouble();
        System.out.println("Введите второе число:");
        double num2 = scanner.nextDouble();
        System.out.println("Введите операцию (+, -, *, /):");
        char operation = scanner.next().charAt(0);
        calculate(num1, num2, operation);
    }
}

