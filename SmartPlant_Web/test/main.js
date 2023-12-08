// Placeholder for our api uri
const baseUrl = "http://localhost:5053/api/temp/100"

const config = {
    headers: {
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json',
    },
  };

Vue.createApp({
    data() {
        return {
            posts: [],
            error: null,
            postId: "",
            post: null

        }
    },

    // life cycle method
    async created() {
        console.log("method called")
        this.getPosts(baseUrl)
    },

    // Access-Control-Allow-Origin
    // Methods
    methods: {
        async getPosts() {
            try {
                console.log('Fetching posts...');
                const response = await axios.get(baseUrl,config);
                console.log('API Response:', response.data);
                this.posts = response.data;
                this.error = null;
            } catch (ex) {
                console.error('Error fetching posts:', ex.message);
                this.posts = [];
                this.error = ex.message;
            }
        },
      }
 }).mount("#app")