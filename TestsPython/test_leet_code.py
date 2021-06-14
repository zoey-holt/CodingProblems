import leet_code_problems as problems

def test_two_sum():
    assert problems.two_sum([2, 7, 11, 15], 9) == [0, 1]
    assert problems.two_sum([3, 2, 4], 6) == [1, 2]
    assert problems.two_sum([3, 3], 6) == [0, 1]

def test_add_two_numbers():
    assert problems.add_two_numbers(problems.ListNode(values=[2,4,3]), problems.ListNode(values=[5,6,4])).to_array() == [7,0,8]
    assert problems.add_two_numbers(problems.ListNode(values=[0]), problems.ListNode(values=[0])).to_array() == [0]
    assert problems.add_two_numbers(problems.ListNode(values=[9,9,9,9,9,9,9]), problems.ListNode(values=[9,9,9,9])).to_array() == [8,9,9,9,0,0,0,1]
    assert problems.add_two_numbers(problems.ListNode(values=[9]), problems.ListNode(values=[1,9,9,9,9,9,9,9,9,9])).to_array() == [0,0,0,0,0,0,0,0,0,0,1]
    assert problems.add_two_numbers(problems.ListNode(values=[1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]), problems.ListNode(values=[5,6,4])).to_array() == [6,6,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]

def test_length_of_longest_substring():
    assert problems.length_of_longest_substring("abcabcbb") == 3
    assert problems.length_of_longest_substring("bbbbb") == 1
    assert problems.length_of_longest_substring("pwwkew") == 3
    assert problems.length_of_longest_substring("") == 0
    assert problems.length_of_longest_substring(" ") == 1
    assert problems.length_of_longest_substring("au") == 2
    assert problems.length_of_longest_substring("dvdf") == 3
