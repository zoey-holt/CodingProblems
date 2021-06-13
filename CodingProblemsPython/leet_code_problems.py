from typing import List

# 1. Two Sum
# Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
# You can return the answer in any order.
# This solution has a time complexity of O(N) where N = nums.Length.
# This solution has a space complexity of O(N) where N = nums.Length.
def two_sum(nums: List[int], target: int) -> List[int]:
    d = {}
    for i, n in enumerate(nums):
        x = target - n
        if x in d:
            return [d[x], i]
        else:
            d[n] = i
    return []

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next