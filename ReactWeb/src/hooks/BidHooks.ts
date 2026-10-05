import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios, { AxiosError, AxiosResponse } from "axios";
import config from "../config";
import { Bid } from "../types/bids";
import Problem from "../types/Problem";

const useFetchBids = (houseId: number) => {
	return useQuery<Bid[], AxiosError<Problem>>({
		queryKey: ["bids", houseId],
		queryFn: () =>
			axios
				.get(`${config.baseApiUrl}/house/${houseId}/bids`)
				.then((response) => response.data),
	});
};

const useAddBid = () => {
	const queryClient = useQueryClient();

	return useMutation<AxiosResponse, AxiosError<Problem>, Bid>({
		mutationFn: (bid) =>
			axios.post(`${config.baseApiUrl}/house/${bid.houseId}/bids`, bid),
		onSuccess: (_response, bid) =>
			queryClient.invalidateQueries({
				queryKey: ["bids", bid.houseId],
			}),
	});
};

export {  useFetchBids,useAddBid };
