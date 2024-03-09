using UnityEngine

public class NN: MonoBehaviour
{
    public Layer hidden1;
    public Layer hidden2;
    public Layer output;
    public class Layer
    {
        public float[,] WeightsArray;
        public float[] BiasesArray;
        public float[] nodeArray;

        private int n_nodes;
        private int n_inputs;

        public Layer(int n_inputs, int n_nodes)
        {
            this.n_nodes = n_nodes;
            this.n_inputs = n_inputs;

            WeightsArray = new float[n_nodes, n_inputs];
            BiasesArray = new float[n_nodes];
            nodeArray = new float[n_nodes];
        }
        // Forward pass = sum of the weights of the inputs multiplied by the biases
        public void forward()
        {

        }
    }
    public void Awake()
    {
        hidden1 = new Layer(2, 4);
        hidden2 = new Layer(4, 4);
        output = new Layer(4, 2);
    }

    
}