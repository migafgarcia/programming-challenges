class Solution {
    public void setZeroes(int[][] matrix) {
        int col0 = 1;
        for (int i = 0; i < matrix.length; i++) {
            if (matrix[i][0] == 0) col0 = 0;
            for (int j = 1; j < matrix[i].length; j++)
                if (matrix[i][j] == 0)
                    matrix[i][0] = matrix[0][j] = 0;
        }


        for (int i = matrix.length - 1; i >= 0; i--) {
            for (int j = matrix[i].length - 1; j >= 1; j--)
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            if (col0 == 0) matrix[i][0] = 0;
        }
    }

    private void printMatrix(int[][] matrix) {
        for (int[] row : matrix) {
            for (int i : row) {
                System.out.print(i + " ");
            }
            System.out.println();
        }
    }
}