using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetKatamari : MonoBehaviour
{
    //Node class for the binary search tree
    public class Node {
        public GameObject planet; // GameObject associated with the node
        public Vector3 position; // Coordinates in 3D space
        public Node left, right;

        public Node (GameObject obj, Vector3 pos) {
            planet = obj;
            position = pos;
            left = right = null;
        }
    }

    public Node root;
    public Vector3[] predefinedCoordinates; //coordinate array

    // Start is called before the first frame update
    void Start() {
        // Construct the binary search tree using predefined coordinates
        foreach (Vector3 coord in predefinedCoordinates) {
            Insert(null, coord); // GameObject is null for now
        }
    }

    // Function to insert a new node with a GameObject, its coordinates, and "won" flag
    public void Insert (GameObject obj, Vector3 pos) {
        root = InsertRec(root, obj, pos);
    }

    // Recursive function to insert a new node
    private Node InsertRec (Node root, GameObject obj, Vector3 pos) {
        // If the tree is empty, return a new node
        if (root == null) {
            root = new Node(obj, pos);
            return root;
        }

        // Otherwise, recur down the tree
        if (Vector3.Distance (pos, root.position) < 0.0001f) {
            // Positions are the same, update the GameObject
            root.planet = obj;
        }
        else if (pos.x < root.position.x || (pos.x == root.position.x && pos.y < root.position.y) || (pos.x == root.position.x && pos.y == root.position.y && pos.z < root.position.z)) {
            root.left = InsertRec(root.left, obj, pos);
        } else {
            root.right = InsertRec(root.right, obj, pos);
        }

        return root;
    }
}
