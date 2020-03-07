#include <gtest/gtest.h>
#include <vector>

/**
 * This problem was recently asked by Google.
 *
 * Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
 *
 * For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
 *
 * Bonus: Can you do this in one pass?
 */

static bool numbers_in_list_add_up_to_value(const std::vector<int>& number_collection, int k)
{
	for (const auto& number : number_collection)
	{
		if (std::find(number_collection.begin(), number_collection.end(), k - number) != number_collection.end())
		{
            return true;
		}
	}

    return false;
}

TEST(Problem001, SolutionTest)
{
    ASSERT_TRUE(numbers_in_list_add_up_to_value(std::vector<int> {10, 15, 3, 7}, 17));
}

