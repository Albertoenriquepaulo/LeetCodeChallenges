var partitionLabels = function (S) {
  let result = [];
  let ind = 0;
  for (let i = 1; i < S.length; i++) {
    console.log(S.length);
    console.log(ind);
    console.log(i);
    console.log("S.slice(ind, i): ", S.slice(ind, i));
    console.log("S[i]:", S[i]);
    console.log("S.slice(ind, i).includes(S[i]): ", S.slice(ind, i).includes(S[i]));
    if (S.slice(ind, i).includes(S[i])) {
      // console.log("first i ", i);
      // console.log(S.slice(ind, i));
      continue;
    } else {
      let isGood = true;
      for (let y = 0; y < result.length; y++) {
        if (result[y].includes(S[i])) {
          result.splice(y);
          ind = result.join('').length;
          isGood = false;
          // console.log("ifInsideFor ", result);
        }
      }
      if (isGood) {
        result.push(S.slice(ind, i));
        ind = i;
        // console.log("ifOutsideFor ", result);
      }
    }
  }
  result.push(S.slice(ind));
  return result.map(x => x.length);
};


partitionLabels("ababcbacadefegdehijhklij");