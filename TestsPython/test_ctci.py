import ctci_problems as problems
from leet_code_problems import TreeNode, is_valid_bst

def test_to_minimal_bst():
    assert problems.to_minimal_bst([]) == None
    assert problems.to_minimal_bst([1,2,3]).to_level_order_array() == [2,1,3]

    actual = problems.to_minimal_bst([1,2,3,4,5,6,7])
    assert is_valid_bst(actual)
    assert actual.to_level_order_array() == [4,2,6,1,3,5,7]
    
    actual = problems.to_minimal_bst([1,2,3,4,5])
    assert is_valid_bst(actual)
    assert actual.to_level_order_array() == [3,2,5,1,None,4,None]
    
    actual = problems.to_minimal_bst([1,2,3,4,5,6,7,8,9,10])
    assert is_valid_bst(actual)
    assert actual.to_level_order_array() == [6,3,9,2,5,8,10,1,None,4,None,7,None]
    
    actual = problems.to_minimal_bst([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])
    assert is_valid_bst(actual)
    assert actual.to_level_order_array() == [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]
