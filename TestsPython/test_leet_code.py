import leet_code_problems as problems

def test_twoSum():
    assert [0, 1] == problems.twoSum(0, [2, 7, 11, 15], 9)
    assert [1, 2] == problems.twoSum(0, [3, 2, 4], 6)
    assert [0, 1] == problems.twoSum(0, [3, 3], 6)
    assert [0, 4, 1, 3] == problems.twoSum(0, [0, 1, 2, 3, 4, 5], 4)

