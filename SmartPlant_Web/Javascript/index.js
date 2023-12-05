// Placeholder for our api uri
const baseUrl = "https://jsonplaceholder.typicode.com/posts"



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

    // Methods
    methods: {
        async getPosts() {
            try {
                console.log('Fetching posts...');
                const response = await axios.get(baseUrl);
                console.log('API Response:', response.data);
                this.posts = response.data;
                this.error = null;
            } catch (ex) {
                console.error('Error fetching posts:', ex.message);
                this.posts = [];
                this.error = ex.message;
            }
        },
        

        clearList() {
            this.posts = []
            this.error = null
        },

        async getPostById(id) {
            const url = baseUrl + "/" + id
            try {
                const response = await axios.get(url)
                this.post = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        }
    }
}).mount("#app")