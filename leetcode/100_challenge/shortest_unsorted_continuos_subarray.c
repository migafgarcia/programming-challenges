int findUnsortedSubarray(int* nums, int size) {
    int beg = -1, end = -2;

    int max = nums[0];

    for(int i = 0; i < size; i++) {
    	max = nums[i] > max ? nums[i] : max;
    	if(nums[i] < max) {
    		end = i;
    	}
    }

    int min = nums[size - 1];
	for(int i = size - 1; i >= 0; i--) {
		min = nums[i] < min ? nums[i] : min;
    	if(nums[i] > min) {
    		beg = i;
    	}
    }

   	printf("%d %d\n", beg, end);

    return end - beg + 1;
}