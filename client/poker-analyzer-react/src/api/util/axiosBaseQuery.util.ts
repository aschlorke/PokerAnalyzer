/* eslint-disable @typescript-eslint/no-unsafe-assignment -- this is the suggested fix from rtkquery */
import { BaseQueryFn } from "@reduxjs/toolkit/query";
import axios, { AxiosError, AxiosRequestConfig } from "axios";

export const axiosBaseQuery =
  (
    { baseUrl }: { baseUrl: string } = { baseUrl: "" }
  ): BaseQueryFn<{
    url: string;
    method?: AxiosRequestConfig["method"];
    data?: AxiosRequestConfig["data"];
    params?: AxiosRequestConfig["params"];
    headers?: AxiosRequestConfig["headers"];
    paramsSerializer?: AxiosRequestConfig["paramsSerializer"];
  }> =>
  async ({ url, method, data, params, headers, paramsSerializer }) => {
    try {
      const result = await axios({
        url: baseUrl + url,
        method,
        data,
        params,
        headers,
        paramsSerializer: paramsSerializer ?? { indexes: true },
      });
      return { data: result.data };
    } catch (axiosError) {
      const err = axiosError as AxiosError;
      return {
        error: {
          status: err.response?.status,
          data: err.response?.data || err.message,
        },
      };
    }
  };
/* eslint-enable @typescript-eslint/no-unsafe-assignment -- this is the suggested fix from rtkquery */
