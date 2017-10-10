double findMedianSortedArrays(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    int total_size = nums1Size + nums2Size;
    
    if(total_size == 0)
        return 0;
    
    int middle = total_size / 2;
    
    int medians[2] = {0, 0};


    for(int i1 = 0, i2 = 0; i1 + i2 < middle + 1;) {
        if(i1 == nums1Size) {
            medians[(i1 + i2) % 2] = nums2[i2++];
            continue;
        }
        if(i2 == nums2Size) {
            medians[(i1 + i2) % 2] = nums1[i1++];
            continue;
        }

        if(nums1[i1] <= nums2[i2])
            medians[(i1 + i2) % 2] = nums1[i1++];
        else
            medians[(i1 + i2) % 2] = nums2[i2++];
    }

    if(total_size % 2 == 0) 
        return (double) (medians[0] + medians[1]) / 2;
    else if(middle % 2 == 0)
        return medians[0];
    else
        return medians[1];
}