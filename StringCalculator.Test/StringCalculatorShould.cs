using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Test {
    public class StringCalculatorShould {


        [Test]
        public void return_0_when_string_is_empty() 
        {
            // Given
            var input = "";
            // When
            var result = StringCalculator.Add(input);
            // Then
            result.Should().Be(0);
        }

        [TestCase("2", 2)]
        [TestCase("1", 1)]
        public void return_a_number_when_input_is_that_number(string input, int expected)
        {
            
            var result = StringCalculator.Add(input);
            
            result.Should().Be(expected);
        }


        [TestCase("1,2", 3)]
        [TestCase("4,2", 6)]
        [TestCase("4,2,3", 9)]
        public void return_addition_when_input_is_any_amount_of_numbers(string input, int expected)
        {

            var result = StringCalculator.Add(input);

            result.Should().Be(expected);
        }
        
        [Test]
        public void return_addition_when_input_has_new_line_as_separator()
        {
            var input = "4,2\n2";

            var result = StringCalculator.Add(input);

            result.Should().Be(8);
        }
        
        [Test]
        public void return_addition_when_delimiter_is_provided_by_input()
        {
            const string input = "//;\n1;2";

            var result = StringCalculator.Add(input);

            result.Should().Be(3);
        }

        [Test]
        public void return_exception_when_input_has_negative_numbers()
        {
            // Given
            const string input = "1,4,-1,-4";

            // Then
            Action act = () => StringCalculator.Add(input);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("negatives not allowed: -1,-4");
        }

        [Test]
        public void ignore_numbers_bigger_than_1000()
        {
            const string input = "2,1001";

            var result = StringCalculator.Add(input);

            result.Should().Be(2);
        }
        
        [Test]
        public void return_substract_negative_numbers()
        {
            const string input = "2,-1,-5,3,-1004";

            var result = StringCalculator.AddWithNegatives(input);

            result.Should().Be(-1);
        }
    }
}