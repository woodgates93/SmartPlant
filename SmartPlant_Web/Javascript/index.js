// Placeholder for our api uri
const baseUrl = "https://jsonplaceholder.typicode.com/posts"
const weatherUrl = "https://api.met.no/weatherapi/locationforecast/2.0/complete"

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
            post: null,
            weather: null,
            locationSuccess: null,
            airTemperature: null,
            relativeHumidity: null,
            uvIndexClearSky: null,

        }
    },

    // life cycle method
    async created() {

        // method call on load 
        console.log("getPosts method called")
        this.getPosts(baseUrl)

        // method call on load
        console.log("getLocation method called")
        await this.getLocation()

        // lat & lon to 3. party API | method call on load
        if (this.locationSuccess) {
            const tempUrl = `${weatherUrl}?lat=${this.locationSuccess.lat}&lon=${this.locationSuccess.lon}`;
            console.log("Weather URL:", tempUrl);
            console.log("getWeatherForecast method called");
            this.getWeatherForecast(tempUrl);
        }
    },

    // Methods
    methods: {
        async getPosts() {
            try {
                console.log('Fetching posts...');

                // async API call with Axios
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

        getLocation() {
            // success or failure to get geolocation
            return new Promise((resolve, reject) => {
                navigator.geolocation.getCurrentPosition((position) => {
                    this.locationSuccess = {
                        lat: position.coords.latitude,
                        lon: position.coords.longitude,
                    };
                    resolve();
                },
                (error) => {
                    console.errorr("Error getting location:", error.message);
                    reject(error.message);
                });
            });            
        },        

        // clears local list of data till next get-call
        clearList() {
            this.posts = []
            this.error = null
        },

        // gets data by id
        async getPostById(id) {
            const url = baseUrl + "/" + id
            try {
                const response = await axios.get(url)
                this.post = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },

        // gets weather data from 3. party API 
        async getWeatherForecast(url) {
            try {
                console.log('Fetching weather data...');
                const weatherResponse = await axios.get(url);
                console.log('Weather API Response:', weatherResponse.data);
                this.weather = weatherResponse.data;

                // extract air_temperature, relative_humidity, and ultraviolet_index_clear_sky from 3. party API
                const currentForecast = this.weather.properties.timeseries[0].data.instant.details;
                this.airTemperature = currentForecast.air_temperature;
                this.relativeHumidity = currentForecast.relative_humidity;
                
                // uv-index might not always have local value due to season or time of day
                const uvIndexClearSky = currentForecast.ultraviolet_index_clear_sky;
                this.uvIndexClearSky = uvIndexClearSky ? uvIndexClearSky : "N/A";

            } catch (ex) {
                console.error('Error fetching weather:', ex.message);
                this.weather = null;
            }
        }
    }
}).mount("#app")
