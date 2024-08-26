namespace AlgoTest.LeetCode.Serialize_and_Deserialize_Binary_Tree;

public class Serialize_and_Deserialize_Binary_Tree
{
    public class Codec {

        public string serialize(TreeNode root) 
        {
            string retVal = "#";
            if(root == null)
            {
                return retVal;
            }
        
            retVal += root.val;
            retVal += serialize(root.left);
            retVal += serialize(root.right);
        
            return retVal;        
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data) 
        {
            var localData = data;
            return deserialize(ref localData);    
        }

        private TreeNode deserialize(ref string data) 
        {
            TreeNode root = null;

            if(data.IndexOf("#", 1) == -1)
            {
                return root;
            }

            var val = data.Substring(1, data.Substring(1).IndexOf("#"));
            if(string.IsNullOrEmpty(val))
            {
                return root;                
            }
        
            root = new TreeNode(int.Parse(val));
        
            data = data.Substring(data.IndexOf("#", 1));
            root.left = deserialize(ref data);
        
            data = data.Substring(data.IndexOf("#", 1));
            root.right = deserialize(ref data);
        
            return root;
        }
    }
}