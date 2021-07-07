from typing import List
from leet_code_problems import TreeNode, Node
import math

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

# 4.4 Check Balanced
# Implement a function to check if a binary tree is balanced. For the purpose of this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any node never differ by more than one.
def check_balanced(root: TreeNode) -> bool:
    return get_height_balance_check(root) >= 0 if root else True

def get_height_balance_check(root: TreeNode) -> int:
    left_height = get_height_balance_check(root.left) if root.left else 0
    if left_height < 0:
        return left_height
    right_height = get_height_balance_check(root.right) if root.right else 0
    if right_height < 0:
        return right_height
    if math.fabs(left_height - right_height) > 1:
        return -1 # signal that subtrees are not balanced
    return max(left_height, right_height) + 1

# 4.7 Build Order
# You are given a list of projects and a list of dependencies (which is a list of pairs of projects, where the second project is dependent on the first project). 
# All of a project's dependencies must be built before the project is. Find a build order that will allow the projects to be built. If there is no valid build order, return an error.
class BuildOrderException(Exception):
    pass

def build_order(projects: List[str], dependencies: List[List[str]]) -> List[str]:
    dependents = {d[1] for d in dependencies}
    independents = {p for p in projects if p not in dependents}
    if dependents and not independents:
        raise BuildOrderException("Circular dependency(ies) detected. Build order cannot be established.")
    if dependents:
        next_dependencies = [d for d in dependencies if d[0] not in [i for i in independents]]
        return list(independents) + build_order(list(dependents), next_dependencies)
    return list(independents)
