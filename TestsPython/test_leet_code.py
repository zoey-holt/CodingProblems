import leet_code_problems as problems

def test_twoSum():
    assert [0, 1] == problems.two_sum([2, 7, 11, 15], 9)
    assert [1, 2] == problems.two_sum([3, 2, 4], 6)
    assert [0, 1] == problems.two_sum([3, 3], 6)

