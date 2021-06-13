from typing import List

# 1. Two Sum
# Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
# You can return the answer in any order.
# This solution has a time complexity of O(N²) where N = nums.Length.
# This solution has a space complexity of O(1).
def twoSum(self, nums: List[int], target: int) -> List[int]:
    list = []
    for i in range(0, len(nums)):
        for j in range(i + 1, len(nums)):
            if nums[i] + nums[j] == target:
                list.append(i)
                list.append(j)
    return list
