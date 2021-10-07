using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Test {
    public class StringCalculatorShould {
        [SetUp]
        public void Setup() {
        }

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

        [Test]
        public void return_1_when_input_is_1()
        {
            var input = "1";

            var result = StringCalculator.Add(input);

            result.Should().Be(1);
        }

        [Test]
        public void return_a_number_when_input_is_that_number()
        {
            var input = "2";

            var result = StringCalculator.Add(input);

            result.Should().Be(2);
        }

        [Test]
        public void return_3_when_input_is_1_2()
        {
            var input = "1,2";

            var result = StringCalculator.Add(input);

            result.Should().Be(3);
        }

        [Test]
        public void return_addition_when_input_is_two_numbers()
        {
            var input = "4,2";

            var result = StringCalculator.Add(input);

            result.Should().Be(6);
        }

        [Test]
        public void return_addition_when_input_is_any_amount_of_numbers()
        {
            var input = "4,2,3";

            var result = StringCalculator.Add(input);

            result.Should().Be(9);
        }
        
        [Test]
        public void return_addition_when_input_has_new_line_as_separator()
        {
            var input = "4,2\n2";

            var result = StringCalculator.Add(input);

            result.Should().Be(8);
        }
    }
}