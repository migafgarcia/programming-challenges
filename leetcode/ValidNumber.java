import java.util.regex.*;
class Solution {
    public boolean isNumber(String s) {
        s = s.trim();
        
        Pattern float_reg = Pattern.compile("[-\\+]?(\\d+)?\\.(\\d+)");
        Pattern float_reg1 = Pattern.compile("[-\\+]?(\\d+)\\.(\\d+)?");
        Pattern int_reg = Pattern.compile("[-\\+]?\\d+");
        Pattern sci_reg = Pattern.compile("[-\\+]?\\.?\\d+\\.?e[-\\+]?\\d+");
        Pattern sci_reg2 = Pattern.compile("[-\\+]?\\d+\\.\\d+\\.?e[-\\+]?\\d+");

        return float_reg.matcher(s).matches() || int_reg.matcher(s).matches() || sci_reg.matcher(s).matches() || float_reg1.matcher(s).matches() || sci_reg2.matcher(s).matches();
    }
}