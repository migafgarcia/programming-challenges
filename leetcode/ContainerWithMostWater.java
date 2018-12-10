import static java.lang.Math.max;
import static java.lang.Math.min;

class Solution {
    public int maxArea(int[] height) {
        int maxArea = 0;
        int left = 0, right = height.length - 1;

        int currentLeft = height[left], currentRight = height[right];

        while(right - left >= 1) {
            maxArea = max(min(currentLeft, currentRight) * (right - left), maxArea);

            if(currentLeft > currentRight)
                currentRight = height[--right];
            else
                currentLeft = height[++left];

        }

        return maxArea;
    }

}
