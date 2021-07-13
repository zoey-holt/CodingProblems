import ctci_problems as problems
from leet_code_problems import TreeNode, Node

def test_route_exists():
    middle = Node(100)
    assert problems.route_exists(Node(0, [middle]), Node(1, [middle])) == True
    assert problems.route_exists(Node(0, [Node(1), Node(2, [middle])]), Node(3, [Node(4, [middle])])) == True
    assert problems.route_exists(Node(0, [Node(1), Node(2, [Node(3)])]), Node(4, [Node(5, [Node(6)])])) == False
    assert problems.route_exists(Node(0, [Node(1), Node(1), Node(1, [middle])]), Node(0, [Node(1), Node(1), Node(1, [middle])])) == True
    assert problems.route_exists(Node(0, [Node(1, [Node(2), Node(2)]), Node(1), Node(1, [middle])]), Node(0, [middle])) == True
    start = Node(0)
    end = Node(111)
    add_children(start, 10)
    add_children(end, 10)
    for c1 in start.children:
        add_children(c1, 10)
        for c2 in c1.children:
            add_children(c2, 10)
    for c1 in end.children:
        add_children(c1, 10)
        for c2 in c1.children:
            add_children(c2, 10)
    start.children[7].children[4].children[8] = middle
    end.children[2].children[9].children[4] = middle
    assert problems.route_exists(start, end) == True

def add_children(node: Node, count: int) -> None:
    children = []
    for i in range(0, count):
        children.append(Node(i))
    node.children = children

def test_to_minimal_bst():
    assert problems.to_minimal_bst([]) == None
    assert problems.to_minimal_bst([1,2,3]).to_level_order_array() == [2,1,3]
    assert problems.to_minimal_bst([1,2,3,4,5,6,7]).to_level_order_array() == [4,2,6,1,3,5,7]
    assert problems.to_minimal_bst([1,2,3,4,5]).to_level_order_array() == [3,2,5,1,None,4,None]
    assert problems.to_minimal_bst([1,2,3,4,5,6,7,8,9,10]).to_level_order_array() == [6,3,9,2,5,8,10,1,None,4,None,7,None]
    assert problems.to_minimal_bst([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]).to_level_order_array() == [8,4,12,2,6,10,14,1,3,5,7,9,11,13,15]

def test_check_balanced():
    assert problems.check_balanced(TreeNode.from_level_order_array([])) == True
    assert problems.check_balanced(TreeNode.from_level_order_array([1])) == True
    assert problems.check_balanced(TreeNode.from_level_order_array([3,9,20,None,None,15,7])) == True
    assert problems.check_balanced(TreeNode.from_level_order_array([1,2,2,3,3,None,None,4,4])) == False
    assert problems.check_balanced(TreeNode.from_level_order_array([1,2,3,4,5,6,None,8])) == True
    assert problems.check_balanced(TreeNode.from_level_order_array([1,None,2,None,3])) == False
    assert problems.check_balanced(TreeNode.from_level_order_array([1,2,2,3,None,None,3,4,None,None,4])) == False

def test_build_order():
    assert problems.build_order([], []) == []
    assert problems.build_order(['a','b','c','d','e','f'], [['a','d'],['f','b'],['b','d'],['f','a'],['d','c']]) in [['e','f','a','b','d','c'],['e','f','b','a','d','c'],['f','e','a','b','d','c'],['f','e','b','a','d','c'],]
    try: problems.build_order(['a','b'], [['a','b'],['b','a']])
    except problems.BuildOrderException as e: assert True
    assert problems.build_order(['a','b','c'], [['b','c'],['a','b']]) == ['a','b','c']
    assert problems.build_order(['a','b','c'], [['b','c'],['a','b'],['a','c']]) == ['a','b','c']
    assert problems.build_order(['a','b','c','d'], [['b','c'],['a','b'],['a','c'],['a','d'],['b','d'],['c','d']]) == ['a','b','c','d']

def test_first_common_ancestor():
    node1 = TreeNode()
    node2 = TreeNode()
    root = TreeNode(100, node1, node2)
    expected = root
    assert problems.first_common_ancestor(root, node1, node2) == expected
    node1 = TreeNode(1)
    node2 = TreeNode(2)
    expected = TreeNode(100, node1, node2)
    root = TreeNode(0, None, expected)
    assert problems.first_common_ancestor(root, node1, node2) == expected
    node1 = TreeNode(1)
    node2 = TreeNode(2, None, node1)
    expected = TreeNode(100, None, node2)
    root = TreeNode(0, None, expected)
    assert problems.first_common_ancestor(root, node1, node2) == expected
    node1 = TreeNode()
    node2 = TreeNode()
    expected = TreeNode(
        100, TreeNode(
            0, node1, 
            TreeNode()),
       TreeNode(
           0, node2, 
           TreeNode()))
    root = TreeNode(0, None, expected)
    assert problems.first_common_ancestor(root, node1, node2) == expected
    node1 = TreeNode()
    node2 = TreeNode()
    expected = TreeNode(
        100, TreeNode(
            0, TreeNode(
                0, TreeNode(
                    0, TreeNode(
                        0, TreeNode(), 
                        TreeNode()), 
                    node1), 
                TreeNode()), 
            TreeNode(
                0, TreeNode(), 
                TreeNode())), 
        TreeNode(
            0, node2, 
            TreeNode(
                0, TreeNode(
                    0, TreeNode(), 
                    TreeNode()))))
    root = TreeNode(0, None, expected)
    assert problems.first_common_ancestor(root, node1, node2) == expected

def test_bst_sequences():
    assert problems.bst_sequences(None) == []
    assert problems.bst_sequences(TreeNode.from_level_order_array([2,1,3])) == [[2,1,3],[2,3,1]]
    assert problems.bst_sequences(TreeNode.from_level_order_array([3,2,5,1,None,4,None])) == [[3,2,5,1,4],[3,5,2,1,4]]
    assert problems.bst_sequences(TreeNode.from_level_order_array([4,2,6,1,3,5,7])) == [[4,2,6,1,3,5,7],[4,2,6,3,1,5,7],[4,6,2,1,3,5,7],[4,6,2,3,1,5,7],[4,2,6,1,3,7,5],[4,2,6,3,1,7,5],[4,6,2,1,3,7,5],[4,6,2,3,1,7,5]]
