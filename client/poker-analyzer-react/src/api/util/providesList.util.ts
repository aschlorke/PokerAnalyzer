export const CollectionTagId = "LIST";

type IdFunc<R> = (result: R) => string | number;

export function providesList<R, T extends string>(
  resultsWithIds: R[] | undefined,
  idFunc: IdFunc<R>,
  tagType: T
) {
  const collectionTag = buildCollectionTag(tagType);

  return resultsWithIds
    ? [
        collectionTag,
        ...buildTagsForCollection(resultsWithIds, idFunc, tagType),
      ]
    : [collectionTag];
}

const buildCollectionTag = <T extends string>(tagType: T) => ({
  type: tagType,
  id: CollectionTagId,
});

const buildTagsForCollection = <R, T extends string>(
  resultsWithIds: R[],
  idFunc: IdFunc<R>,
  tagType: T
) => {
  return resultsWithIds.map((i) => ({ type: tagType, id: idFunc(i) }));
};
