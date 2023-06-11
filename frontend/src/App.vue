<template>
	<section>
		<div>
			<h2>GET ALL</h2>
			<button @click="getAllDoctors">AllDoctors</button>
			<div v-if="isValid">
				<ul v-for="doctor in doctors" :key="doctor.id">
					<li>
						ID: {{ doctor.id }} <br />
						FullName: {{ doctor.fullName }}
					</li>
				</ul>
			</div>
		</div>
	</section>
</template>

<script>
import axios from "axios";
const API = "https://localhost:44389/api/doctors";

export default {
	data() {
		return {
			isValid: true,
			doctors: [],
		};
	},
	methods: {
		async getAllDoctors() {
			this.isValid = true;
			try {
				await axios.get(API).then((result) => {
					const { data } = result;
					this.doctors = data;
				});
			} catch (error) {
				this.isValid = false;
			}
		},
	},
};
</script>

<style>
#app {
	font-family: sans-serif;
	text-align: center;
}
</style>
