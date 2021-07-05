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
