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

def test_find_median_sorted_arrays():
    assert problems.find_median_sorted_arrays([1,3], [2]) == 2
    assert problems.find_median_sorted_arrays([1,2], [3,4]) == 2.5
    assert problems.find_median_sorted_arrays([0,0], [0,0]) == 0
    assert problems.find_median_sorted_arrays([], [1]) == 1
    assert problems.find_median_sorted_arrays([2], []) == 2
    assert problems.find_median_sorted_arrays([], [1,2,3,4,5]) == 3
    assert problems.find_median_sorted_arrays([100000], [100001]) == 100000.5
    assert problems.find_median_sorted_arrays([4], [1,2,3,5,6]) == 3.5
    assert problems.find_median_sorted_arrays([], []) == 0

def test_remove_duplicates():
    input = [1,1,2]
    assert problems.remove_duplicates(input) == 2
    assert input[0:2] == [1,2]
    input = [0,0,1,1,1,2,2,3,3,4]
    assert problems.remove_duplicates(input) == 5
    assert input[0:5] == [0,1,2,3,4]

def test_remove_element():
    input = [3,2,2,3]
    expected = [2,2]
    assert problems.remove_element(input, 3) == len(expected)
    assert input[0:len(expected)] == expected
    input = [0,1,2,2,3,0,4,2]
    expected = [0,1,3,0,4]
    assert problems.remove_element(input, 2) == len(expected)
    assert input[0:len(expected)] == expected

def test_is_valid_sudoku():
    assert problems.is_valid_sudoku([
        ['5','3','.', '.','7','.', '.','.','.'],
        ['6','.','.', '1','9','5', '.','.','.'],
        ['.','9','8', '.','.','.', '.','6','.'],
                                   
        ['8','.','.', '.','6','.', '.','.','3'],
        ['4','.','.', '8','.','3', '.','.','1'],
        ['7','.','.', '.','2','.', '.','.','6'],
                                   
        ['.','6','.', '.','.','.', '2','8','.'],
        ['.','.','.', '4','1','9', '.','.','5'],
        ['.','.','.', '.','8','.', '.','7','9']]) == True
    assert problems.is_valid_sudoku([
        ['8','3','.', '.','7','.', '.','.','.'],
        ['6','.','.', '1','9','5', '.','.','.'],
        ['.','9','8', '.','.','.', '.','6','.'],
                                   
        ['8','.','.', '.','6','.', '.','.','3'],
        ['4','.','.', '8','.','3', '.','.','1'],
        ['7','.','.', '.','2','.', '.','.','6'],
                                   
        ['.','6','.', '.','.','.', '2','8','.'],
        ['.','.','.', '4','1','9', '.','.','5'],
        ['.','.','.', '.','8','.', '.','7','9']]) == False

def test_inorder_traversal():
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([1,None,2,3])) == [1,3,2]
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([])) == []
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([1])) == [1]
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([1,2])) == [2,1]
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([1,None,2])) == [1,2]
    assert problems.inorder_traversal(problems.TreeNode.from_level_order_array([1,2,3,4,5,6,7])) == [4,2,5,1,6,3,7]

def test_inorder_traversal_iterative():
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([1,None,2,3])) == [1,3,2]
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([])) == []
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([1])) == [1]
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([1,2])) == [2,1]
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([1,None,2])) == [1,2]
    assert problems.inorder_traversal_iterative(problems.TreeNode.from_level_order_array([1,2,3,4,5,6,7])) == [4,2,5,1,6,3,7]

def test_is_valid_bst():
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([2,1,3])) == True
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([5,1,4,None,None,3,6])) == False
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([])) == True
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([1])) == True
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([2,2,2])) == False
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([5,4,6,None,None,3,7])) == False
    assert problems.is_valid_bst(problems.TreeNode.from_level_order_array([3,1,5,0,2,4,6])) == True

def test_binary_tree_level_order():
    assert problems.binary_tree_level_order(problems.TreeNode.from_level_order_array([3,9,20,None,None,15,7])) == [[3],[9,20],[15,7]]
    assert problems.binary_tree_level_order(problems.TreeNode.from_level_order_array([1])) == [[1]]
    assert problems.binary_tree_level_order(problems.TreeNode.from_level_order_array([])) == []
    assert problems.binary_tree_level_order(problems.TreeNode.from_level_order_array([-9,-3,2,None,4,4,0,-6,None,-5])) == [[-9],[-3,2],[4,4,0],[-6,-5]]

def test_nary_tree_level_order():
    assert problems.nary_tree_level_order(problems.Node.from_level_order_array([])) == []
    assert problems.nary_tree_level_order(problems.Node.from_level_order_array([1])) == [[1]]
    assert problems.nary_tree_level_order(problems.Node.from_level_order_array([1,None,3,2,4,None,5,6])) == [[1],[3,2,4],[5,6]]
    assert problems.nary_tree_level_order(problems.Node.from_level_order_array([1,None,2,3,4,5,None,None,6,7,None,8,None,9,10,None,None,11,None,12,None,13,None,None,14])) == [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
    
def test_longest_ones():
    return # TODO: remove this when testable
    assert problems.longest_ones([0], 0) == 0
    assert problems.longest_ones([1,1,1,0,0,0,1,1,1,1,0], 2) == 6
    assert problems.longest_ones([0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], 3) == 10
    assert problems.longest_ones([0,0,0,1], 4) == 4
    assert problems.longest_ones([1,1,1,0,0,1,0,1,0,1,0,1,1,0,0,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,0,0,0,1,1,0,1,1,1,1,1,1,0,1,0,0,0,0,1,0,1,1,0,1,0,1,0,0,1,1,0,1,0,1,0,1,1,1,0,0,1,0,1,1,1,1,1,1,1,1,1,0,0,0,1,1,0,0,1,0,0,1,1,1,1,1,1,1,1,0,0,0,1,1,1,0,0,0,1,1,0,1,1,1,1,0,1,0,1,0,1,0,1,1,0,0,1,1,1,1,0,1,0,0,0,1,1,0,0,1,0,1,0,1,1,1,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,1,0,1,0,1,1,0,1,1,0,1,0,1,1,0,1,0,1,1,1,0,1,0,0,1,0,0,0,0,1,1,0,1,1,1,0,0,1,1,0,0,1,0,0,1,0,0,0,0,1,0,0,1,1,0,0,1,1,1,1,0,0,1,0,0,0,0,1,1,1,1,0,0,1,0,0,1,0,0,0,0,0,1,1,0,1,1,0,1,0,0,1,1,1,0,1,0,0,0,0,1,0,0,1,1,0,0,1,0,1,0,1,0,1,1,1,0,0,0,0,1,0,0,1,0,1,1,1,1,1,0,0,1,1,0,1,1,1,0,1,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,0,0,0,0,1,1,0,1,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,1,0,1,1,1,1,0,0,1,0,1,1,1,0,1,1,0,1,0,0,1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,1,0,1,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0,1,1,1,0,1,0,1,0,1,1,1,0,0,1,0,1,0,1,1,0,0,1,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,1,0,1,1,0,1,1,0,1,0,1,1,1,0,0,1,0,1,1,0,0,0,0,1,1,0,1,1,1,0,1,1,1,1,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,1,1,0,0,0,1,0,1,1,1,0,0,0,0,0,1,1,0,1,0,0,0,0,1,1,0,0,1,0,1,0,0,1,1,1,0,1,0,1,1,0,0,1,1,0,1,1,0,0,0,0,0,0,0,1,0,1,1,0,1,1,0,0,0,0,0,0,1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,1,0,1,1,0,1,1,1,0,0,1,0,1,1,1,1,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,0,0,1,1,1,0,0,0,0,1,0,1,0,0,0,1,0,0,1,1,1,1,1,0,1,0,1,0,0,0,0,0,1,0,0,1,0,0,1,1,0,0,1,1], 144) == 322
