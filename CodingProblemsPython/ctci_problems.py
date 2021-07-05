from typing import List
from leet_code_problems import TreeNode, Node

# 4.1 Route Between Nodes
# Given a directed graph from two nodes (S and E), design an algorithm to find out whether there is a route from S to E.
def route_exists(start: Node, end: Node) -> bool:
    if start == end:
        return True
    start.seen = True
    end.seen = True
    # TODO: keep from storing entire levels in memory
    start_level = [start]
    end_level = [end]
    while start_level and end_level:
        next_start_level = []
        for n in start_level:
            next_start_level += [c for c in n.children if c.seen is False]
        start_level = next_start_level
        for n in start_level:
            if n in end_level:
                return True
        for n in end_level:
            n.seen = True

        next_end_level = []
        for n in end_level:
            next_end_level += [c for c in n.children if c.seen is False]
        end_level = next_end_level
        for n in end_level:
            if n in start_level:
                return True
        for n in start_level:
            n.seen = True

    return False

# 4.2 Minimal Tree
# Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height.
def to_minimal_bst(nums: List) -> TreeNode:
    if not nums: return None
    root_idx = int(len(nums) / 2)
    root = TreeNode(nums[root_idx])
    root.left = to_minimal_bst(nums[:root_idx])
    root.right = to_minimal_bst(nums[root_idx+1:])
    return root
