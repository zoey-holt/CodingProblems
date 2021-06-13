import leet_code_problems as problems

def test_two_sum():
    assert [0, 1] == problems.two_sum([2, 7, 11, 15], 9)
    assert [1, 2] == problems.two_sum([3, 2, 4], 6)
    assert [0, 1] == problems.two_sum([3, 3], 6)

def test_add_two_numbers():
    assert [7,0,8] == problems.add_two_numbers(problems.ListNode(values=[2,4,3]), problems.ListNode(values=[5,6,4])).to_array()
    assert [0] == problems.add_two_numbers(problems.ListNode(values=[0]), problems.ListNode(values=[0])).to_array()
    assert [8,9,9,9,0,0,0,1] == problems.add_two_numbers(problems.ListNode(values=[9,9,9,9,9,9,9]), problems.ListNode(values=[9,9,9,9])).to_array()
    assert [0,0,0,0,0,0,0,0,0,0,1] == problems.add_two_numbers(problems.ListNode(values=[9]), problems.ListNode(values=[1,9,9,9,9,9,9,9,9,9])).to_array()
    assert [6,6,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1] == problems.add_two_numbers(problems.ListNode(values=[1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]), problems.ListNode(values=[5,6,4])).to_array()

